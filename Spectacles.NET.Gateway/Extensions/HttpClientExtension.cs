using System.Net.Http;
using System.Threading.Tasks;

namespace Spectacles.NET.Gateway.Extensions
{
	/// <summary>
	/// Extension Methods of HttpClient
	/// </summary>
	public static class HttpClientExtension
	{
		/// <summary>
		/// Helper Method to send a Http Get Request and throws an exception if the StatusCode is not a Success Code
		/// </summary>
		/// <param name="client">The HttpClient this request will be send with</param>
		/// <param name="uri">The uri of the Request</param>
		/// <returns>HttpResponse</returns>
		public static async Task<HttpResponseMessage> GetAndConfirmAsync(this HttpClient client, string uri)
		{
			var res = await client.GetAsync(uri);
			res.EnsureSuccessStatusCode();
			return res;
		}
	}
}