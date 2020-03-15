using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Spectacles.NET.Rest.APIError;
using Spectacles.NET.Types;
using Spectacles.NET.Util.Logging;

namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	///     Class representing a Request to the Discord REST API.
	/// </summary>
	public class Request
	{
		/// <summary>
		///     Creates a new instance of the Request class.
		/// </summary>
		/// <param name="bucket">The bucket this request was created in.</param>
		/// <param name="content">The HTTP Content of this request.</param>
		/// <param name="method">The HTTP Method of this request.</param>
		/// <param name="url">The URL of this request.</param>
		/// <param name="reason">The optional AuditLog reason of this request.</param>
		public Request(IBucket bucket, HttpContent content, HttpMethod method, string url, string reason)
		{
			Bucket = bucket;
			Content = content;
			Method = method;
			URL = url;
			Reason = reason;
		}

		/// <summary>
		///     How often this request was retried on a 5xx response.
		/// </summary>
		private int Retries { get; set; }

		/// <summary>
		///     The HTTP Method of this Request.
		/// </summary>
		private HttpMethod Method { get; }

		/// <summary>
		///     The URL of this Request.
		/// </summary>
		private string URL { get; }

		/// <summary>
		///     The HTTP Content of this Request (eg. Json or form-data body).
		/// </summary>
		private HttpContent Content { get; }

		/// <summary>
		///     The Bucket this request is queued in.
		/// </summary>
		private IBucket Bucket { get; }

		/// <summary>
		///     The optional AuditLog Reason of this Request.
		/// </summary>
		private string Reason { get; }

		/// <summary>
		///     The timeout of this request in ms.
		/// </summary>
		private int Timeout { get; set; } = 100;

		/// <summary>
		///     The RestClient of this Request (from the Bucket).
		/// </summary>
		private RestClient Client
			=> Bucket.Client;

		/// <summary>
		///     The Success event of this request.
		/// </summary>
		public event EventHandler<string> Success;

		/// <summary>
		///     The Error event of this request.
		/// </summary>
		public event EventHandler<Exception> Error;

		/// <summary>
		///     Executes this Request and Updates the Ratelimit information of the Bucket.
		/// </summary>
		/// <returns></returns>
		public async Task Execute()
		{
			HttpRequestMessage request;

			if (Method.Method == "GET")
			{
				Uri uri;
				try
				{
					uri = new UriBuilder($"{APIEndpoints.APIBaseURL}{URL}")
					{
						Query = Content != null ? await ((FormUrlEncodedContent) Content).ReadAsStringAsync() : null
					}.Uri;
				}
				catch (Exception e)
				{
					Error?.Invoke(this, e);
					return;
				}

				request = new HttpRequestMessage(Method, uri);
			}
			else
			{
				request = new HttpRequestMessage(Method, URL)
				{
					Content = Content
				};
			}

			if (Reason != null) request.Headers.Add("X-Audit-Log-Reason", Reason);

			HttpResponseMessage res;
			try
			{
				_log(LogLevel.DEBUG, "Sending Request...");
				res = await Client.HttpClient.SendAsync(request);
				_log(LogLevel.DEBUG, $"Received Response {res.StatusCode}");
			}
			catch (Exception e)
			{
				Error?.Invoke(this, e);
				return;
			}

			var ratelimit = new RateLimitInfo(res.Headers.ToDictionary(a => a.Key.ToLower(), a => a.Value.First()));

			_log(LogLevel.DEBUG,
				$"Created Ratelimit Info:\nLag: {ratelimit.Lag.TotalSeconds} Seconds\nLimit: {ratelimit.Limit}\nRemaining: {ratelimit.Remaining}\nReset: {ratelimit.Reset}\nGlobal Ratelimited: {ratelimit.IsGlobal}\nRetry-After: {ratelimit.RetryAfter}");

			var statusCode = (int) res.StatusCode;

			string content;
			try
			{
				content = await res.Content.ReadAsStringAsync();
				_log(LogLevel.DEBUG, "Parsed Content");
			}
			catch (Exception e)
			{
				Error?.Invoke(this, e);
				return;
			}

			if (ratelimit.Limit != null && ratelimit.Remaining != null) await _handleHeaders(ratelimit);

			if (res.StatusCode == HttpStatusCode.TooManyRequests)
			{
				await _handleTooManyRequests(ratelimit);
				Bucket.Enqueue(this);
			}
			else if (statusCode >= 500 && statusCode < 600)
			{
				_internalServerError();
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

		private void _internalServerError()
		{
			Retries++;
			if (Retries > 1)
			{
				Error?.Invoke(this, new DiscordAPIException(500, null, $"{HttpStatusCode.InternalServerError}"));
				return;
			}

			Task.Run(async () =>
			{
				await Task.Delay(1000 + new Random().Next(1, 100) - 5);
				Bucket.Enqueue(this);
			}).ConfigureAwait(false);
		}

		private async Task _handleHeaders(RateLimitInfo ratelimit)
		{
			_log(LogLevel.DEBUG, "Updating Bucket Ratelimit information");
			try
			{
				if (ratelimit.Remaining != null)
				{
					await Bucket.SetRemaining((int) ratelimit.Remaining);
					_log(LogLevel.DEBUG, $"Remaining: {ratelimit.Remaining}");
				}

				if (ratelimit.Limit != null)
				{
					await Bucket.SetLimit((int) ratelimit.Limit);
					_log(LogLevel.DEBUG, $"Limit: {ratelimit.Limit}");
				}

				if (ratelimit.Reset != null)
				{
					await Bucket.SetTimeout(
						TimeSpan.FromMilliseconds(((DateTimeOffset) ratelimit.Reset - DateTimeOffset.UtcNow)
							.TotalMilliseconds));
					_log(LogLevel.DEBUG,
						$"Reset: {TimeSpan.FromMilliseconds(((DateTimeOffset) ratelimit.Reset - DateTimeOffset.UtcNow).TotalMilliseconds)}");
				}

				_log(LogLevel.DEBUG, "Updated Bucket Ratelimit information");
				Timeout = 100;
			}
			catch (Exception)
			{
				Timeout *= 2;
				_log(LogLevel.WARN,
					$"Could not update Ratelimit information, retrying in {TimeSpan.FromMilliseconds(Timeout).TotalSeconds} Seconds");
				await Task.Delay(Timeout);
				await _handleHeaders(ratelimit);
			}
		}

		private async Task _handleTooManyRequests(RateLimitInfo ratelimit)
		{
			_log(LogLevel.WARN, "Got 429 Response, this should normally not happen");
			try
			{
				if (ratelimit.RetryAfter != null)
				{
					await Bucket.SetTimeout(TimeSpan.FromMilliseconds((int) ratelimit.RetryAfter));
					_log(LogLevel.DEBUG,
						$"Timeout: {TimeSpan.FromMilliseconds((int) ratelimit.RetryAfter).TotalMilliseconds}");
				}

				if (ratelimit.IsGlobal && ratelimit.RetryAfter != null && Client.GlobalTimeout == null)
				{
					await Bucket.SetGloballyLimited(TimeSpan.FromMilliseconds((int) ratelimit.RetryAfter));
					_log(LogLevel.DEBUG,
						$"Global Limited: {TimeSpan.FromMilliseconds((int) ratelimit.RetryAfter).TotalMilliseconds}");
				}

				Timeout = 100;
			}
			catch (Exception)
			{
				_log(LogLevel.WARN,
					$"Could not update Ratelimit information, retrying in {TimeSpan.FromMilliseconds(Timeout).TotalSeconds} Seconds");
				Timeout *= 2;
				await Task.Delay(Timeout);
				await _handleTooManyRequests(ratelimit);
			}
		}

		private void _log(LogLevel logLevel, string message)
			=> Client.CreateLog(logLevel, message, $"[{Method}] {URL}");
	}
}
