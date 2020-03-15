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
		public int? RetryAfter { get; }

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
			IsGlobal = headers.TryGetValue("x-ratelimit-global", out var temp) &&
			           bool.TryParse(temp, out var isGlobal) && isGlobal;
			Limit = headers.TryGetValue("x-ratelimit-limit", out temp) &&
			        int.TryParse(temp, out var limit)
				? limit
				: (int?) null;
			Remaining = headers.TryGetValue("x-ratelimit-remaining", out temp) &&
			            int.TryParse(temp, out var remaining)
				? remaining
				: (int?) null;
			Lag = headers.TryGetValue("date", out temp) &&
			      DateTimeOffset.TryParse(temp, out var date)
				? date - DateTimeOffset.UtcNow
				: TimeSpan.Zero;
			Reset = headers.TryGetValue("x-ratelimit-reset", out temp) &&
			        int.TryParse(temp, out var reset)
				? DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(Math.Ceiling(reset - Lag.TotalSeconds)))
				: (DateTimeOffset?) null;
			RetryAfter = headers.TryGetValue("retry-after", out temp) &&
			             int.TryParse(temp, out var retryAfter)
				? retryAfter
				: (int?) null;
		}
	}
}
