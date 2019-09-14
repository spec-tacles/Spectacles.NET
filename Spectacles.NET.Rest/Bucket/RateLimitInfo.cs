using System;
using System.Collections.Generic;

namespace Spectacles.NET.Rest.Bucket
{
	/// <summary>
	///     Struct representing information about Ratelimits.
	/// </summary>
	public struct RateLimitInfo
	{
		/// <summary>
		///     If This Ratelimit is Global.
		/// </summary>
		public bool IsGlobal { get; }

		/// <summary>
		///     The amount of request that can be done before waiting.
		/// </summary>
		public int? Limit { get; }

		/// <summary>
		///     The remaining amount of request that can be done.
		/// </summary>
		public int? Remaining { get; }

		/// <summary>
		///     Only there if response code is 429, represents the time to wait before doing another request in ms.
		/// </summary>
		public double? RetryAfter { get; }

		/// <summary>
		///     The difference between the discord api and the local time.
		/// </summary>
		public TimeSpan Lag { get; }

		/// <summary>
		///     The timeout before the ratelimit resets.
		/// </summary>
		public DateTimeOffset? Reset { get; }

		internal RateLimitInfo(IReadOnlyDictionary<string, string> headers)
		{
			IsGlobal = headers.TryGetValue("X-RateLimit-Global", out var temp) &&
			           bool.TryParse(temp, out var isGlobal) && isGlobal;
			Limit = headers.TryGetValue("X-RateLimit-Limit", out temp) &&
			        int.TryParse(temp, out var limit)
				? limit
				: (int?) null;
			Remaining = headers.TryGetValue("X-RateLimit-Remaining", out temp) &&
			            int.TryParse(temp, out var remaining)
				? remaining
				: (int?) null;
			Lag = headers.TryGetValue("Date", out temp) &&
			      DateTimeOffset.TryParse(temp, out var date)
				? date - DateTimeOffset.UtcNow
				: TimeSpan.Zero;
			Reset = headers.TryGetValue("X-RateLimit-Reset", out temp) &&
			        double.TryParse(temp, out var reset)
				? DateTimeOffset.FromUnixTimeSeconds((long) (reset - Lag.TotalMilliseconds))
				: (DateTimeOffset?) null;
			RetryAfter = headers.TryGetValue("Retry-After", out temp) &&
			             double.TryParse(temp, out var retryAfter)
				? retryAfter
				: (double?) null;
		}
	}
}
