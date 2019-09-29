using System;
using System.Linq;

namespace Spectacles.NET.Util
{
	/// <summary>
	/// Util Methods used in Spectacles.NET
	/// </summary>
	public static class Util
	{
		private static Random Random { get; } = new Random();
		private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
		
		/// <summary>
		/// Generates random strings with a specific length
		/// </summary>
		/// <param name="length">The length of the random string</param>
		/// <returns>string</returns>
		public static string RandomString(int length)
			=> new string(Enumerable.Repeat(_chars, length)
				.Select(s => s[Random.Next(s.Length)]).ToArray());
	}
}
