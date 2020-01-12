using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Spectacles.NET.Gateway
{
	/// <summary>
	/// Singletons 
	/// </summary>
	public static class Singletons
	{
		private static Lazy<HttpClient> LazyHttpClient { get; } = new Lazy<HttpClient>();
		
		/// <summary>
		/// All Known Gateway
		/// </summary>
		public static ConcurrentDictionary<string, IGateway> Gateways { get; } = new ConcurrentDictionary<string, IGateway>();

		/// <summary>
		/// Singleton HttpClient
		/// </summary>
		public static HttpClient HttpClient
			=> LazyHttpClient.Value;
	}
}
