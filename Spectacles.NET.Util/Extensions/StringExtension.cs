namespace Spectacles.NET.Util.Extensions
{
	/// <summary>
	///     Extensions to the String class
	/// </summary>
	public static class StringExtension
	{
		/// <summary>
		///     Removes The `Bot` or `Bearer` Prefix from a token
		/// </summary>
		/// <param name="str">The target string</param>
		/// <returns>String without Prefix</returns>
		public static string RemoveBotPrefix(this string str)
			=> str.Replace(@"/^(Bot|Bearer)\s*/i", "");
	}
}
