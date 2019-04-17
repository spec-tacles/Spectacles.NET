using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Spectacles.NET.Rest.APIError;
using Spectacles.NET.Types;

namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	/// Class representing a Request to the Discord REST API.
	/// </summary>
	public class Request
	{
		/// <summary>
		/// The Success event of this request.
		/// </summary>
		public event EventHandler<string> Success;
		
		/// <summary>
		/// The Error event of this request.
		/// </summary>
		public event EventHandler<Exception> Error;

		/// <summary>
		/// How often this request was retried on a 5xx response.
		/// </summary>
		private int Retries { get; set; }

		/// <summary>
		/// The HTTP Method of this Request.
		/// </summary>
		private RequestMethod Method { get; }

		/// <summary>
		/// The URL of this Request.
		/// </summary>
		private string URL { get; }

		/// <summary>
		/// The HTTP Content of this Request (eg. Json or form-data body).
		/// </summary>
		private HttpContent Content { get; }

		/// <summary>
		/// The Bucket this request is queued in.
		/// </summary>
		private IBucket Bucket { get; }
		
		/// <summary>
		/// The optional AuditLog Reason of this Request.
		/// </summary>
		private string Reason { get; }

		/// <summary>
		/// The timeout of this request in ms.
		/// </summary>
		private int Timeout { get; set; } = 100;

		/// <summary>
		/// The RestClient of this Request (from the Bucket).
		/// </summary>
		private RestClient Client
			=> Bucket.Client;

		/// <summary>
		/// Creates a new instance of the Request class.
		/// </summary>
		/// <param name="bucket">The bucket this request was created in.</param>
		/// <param name="content">The HTTP Content of this request.</param>
		/// <param name="method">The HTTP Method of this request.</param>
		/// <param name="url">The URL of this request.</param>
		/// <param name="reason">The optional AuditLog reason of this request.</param>
		public Request(IBucket bucket, HttpContent content, RequestMethod method, string url, string reason)
		{
			Bucket = bucket;
			Content = content;
			Method = method;
			URL = url;
			Reason = reason;
		}

		/// <summary>
		/// Executes this Request and Updates the Ratelimit information of the Bucket.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the RequestMethod is not an valid enum</exception>
		public async Task Execute()
		{
			HttpRequestMessage request;
			switch (Method)
			{
				case RequestMethod.GET:
					Uri uri;
					try
					{
						uri = new UriBuilder($"{APIEndpoints.BaseURL}{URL}")
						{
							Query = Content != null ? await ((FormUrlEncodedContent) Content).ReadAsStringAsync() : null
						}.Uri;
					}
					catch (Exception e)
					{
						Error?.Invoke(this, e);
						return;
					}
					request = new HttpRequestMessage(HttpMethod.Get, uri);
					break;
				case RequestMethod.POST:
					request = new HttpRequestMessage(HttpMethod.Post, URL);
					request.Content = Content;
					break;
				case RequestMethod.DELETE:
					request = new HttpRequestMessage(HttpMethod.Delete, URL);
					request.Content = Content;
					break;
				case RequestMethod.PUT:
					request = new HttpRequestMessage(HttpMethod.Put, URL);
					request.Content = Content;
					break;
				case RequestMethod.PATCH:
					request = new HttpRequestMessage(HttpMethod.Patch, URL);
					request.Content = Content;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(Method), Method, null);
			}
			
			if (Reason != null) request.Headers.Add("X-Audit-Log-Reason", HttpUtility.UrlEncode(Reason));

			HttpResponseMessage res;
			try
			{
				res = await Client.HttpClient.SendAsync(request);
			}
			catch (Exception e)
			{
				Error?.Invoke(this, e);
				return;
			}

			var ratelimit = new RateLimitInfo(res.Headers.ToDictionary(a => a.Key, a => a.Value.First()));
			
			var statusCode = (int) res.StatusCode;

			string content;
			try
			{
				content = await res.Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				Error?.Invoke(this, e);
				return;
			}

			await _handleHeaders(ratelimit);

			if (res.StatusCode == HttpStatusCode.TooManyRequests)
			{
				await _handleTooManyRequests(ratelimit);
				Bucket.Enqueue(this);
			} else if (statusCode >= 500 && statusCode < 600)
			{
				Retries++;
				if (Retries > 1)
				{
					Error?.Invoke(this, new DiscordAPIException(500, null, $"{HttpStatusCode.InternalServerError}"));
					return;
				}
#pragma warning disable 4014
				Task.Run(async () =>
				{
					await Task.Delay(1000 + new Random().Next(1, 100) - 5);
					Bucket.Enqueue(this);
				}).ConfigureAwait(false);
#pragma warning restore 4014
			}
			else if (!res.IsSuccessStatusCode)
			{
				var error = JsonConvert.DeserializeObject<DiscordAPIErrorResponse>(content);
				Error?.Invoke(this, new DiscordAPIException(statusCode, error.Code, error.Message));
			}
			else
			{
				Success?.Invoke(this, content);
			}
		}

		private async Task _handleHeaders(RateLimitInfo ratelimit)
		{
			try
			{
				if (ratelimit.Remaining != null) await Bucket.SetRemaining((int) ratelimit.Remaining);
				if (ratelimit.Limit != null) await Bucket.SetLimit((int) ratelimit.Limit);
				if (ratelimit.Reset != null)
					await Bucket.SetTimeout((int) ((DateTimeOffset) ratelimit.Reset - DateTimeOffset.UtcNow)
						.TotalMilliseconds);
				Timeout = 100;
			}
			catch (Exception)
			{
				Timeout *= 2;
				await Task.Delay(Timeout);
				await _handleHeaders(ratelimit);
			}

		}

		private async Task _handleTooManyRequests(RateLimitInfo ratelimit)
		{
			try
			{
				if (ratelimit.RetryAfter != null) await Bucket.SetTimeout((int) ratelimit.RetryAfter);
				if (ratelimit.IsGlobal)
				{
					if (ratelimit.RetryAfter != null && Client.GlobalTimeout == null)
						await Bucket.SetGloballyLimited((int) ratelimit.RetryAfter);
				}
				Timeout = 100;
			}
			catch (Exception)
			{
				Timeout *= 2;
				await Task.Delay(Timeout);
				await _handleTooManyRequests(ratelimit);
			}
		}
	}
}