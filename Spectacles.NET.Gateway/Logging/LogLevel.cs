namespace Spectacles.NET.Gateway.Logging
{
	/// <summary>
	///     The LogLevel of all Logs.
	/// </summary>
	public enum LogLevel
	{
		// ReSharper disable once UnusedMember.Global
		/// <summary>
		///     Most detailed information. Expect these to be written to logs only.
		/// </summary>
		TRACE,

		/// <summary>
		///     Detailed information on the flow through the system. Expect these to be written to logs only. Generally speaking,
		///     most lines logged by your application should be written as DEBUG.
		/// </summary>
		DEBUG,

		/// <summary>
		///     Interesting runtime events (startup/shutdown). Expect these to be immediately visible on a console, so be
		///     conservative and keep to a minimum.
		/// </summary>
		INFO,

		/// <summary>
		///     Use of deprecated APIs, poor use of API, 'almost' errors, other runtime situations that are undesirable or
		///     unexpected, but not necessarily "wrong". Expect these to be immediately visible on a status console.
		/// </summary>
		WARN,

		/// <summary>
		///     Other runtime errors or unexpected conditions. Expect these to be immediately visible on a status console.
		/// </summary>
		ERROR
	}
}
