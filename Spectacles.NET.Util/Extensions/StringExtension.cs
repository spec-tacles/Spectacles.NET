using System.Text.RegularExpressions;

namespace Spectacles.NET.Util.Extensions
{
	/// <summary>
	///     Extensions to the String class
	/// </summary>
	public static class StringExtension
	{
		private static Regex Regex { get; } = new Regex(@"^(Bot|Bearer)\s", RegexOptions.IgnoreCase);
		
		/// <summary>
		///     Removes The `Bot` or `Bearer` Prefix from a token
		/// </summary>
		/// <param name="str">The target string</param>
		/// <returns>String without Prefix</returns>
		public static string RemoveBotPrefix(this string str)
			=> Regex.Replace(str, string.Empty);
	}
}
