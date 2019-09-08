namespace Spectacles.NET.Rest.Util
{
	/// <summary>
	/// Constants used in Spectacles.NET.Rest
	/// </summary>
	public static class Constants
	{
		/// <summary>
		/// Global ratelimit key
		/// </summary>
		public const string Global = "global";

		/// <summary>
		/// Remaining ratelimit key
		/// </summary>
		/// <param name="route">The route of the Bucket</param>
		/// <returns></returns>
		public static string Remaining(string route) 
			=> $"{route}:remaining";

		/// <summary>
		/// Route ratelimit key
		/// </summary>
		/// <param name="route">The route of the bucket</param>
		/// <returns></returns>
		public static string Limit(string route)
			=> $"{route}:limit";
	}
}