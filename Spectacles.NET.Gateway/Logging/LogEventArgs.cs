using System;

namespace Spectacles.NET.Gateway.Logging
{
	/// <inheritdoc />
	/// <summary>
	/// Event Args used for emitting Logs.
	/// </summary>
	public class LogEventArgs : EventArgs
	{
		/// <summary>
		/// The LogLevel of this message.
		/// </summary>
		public LogLevel LogLevel { get; }
		
		/// <summary>
		/// The message.
		/// </summary>
		public string Message { get; }

		/// <inheritdoc />
		/// <summary>
		/// Creates a new instance of LogEventArgs
		/// </summary>
		/// <param name="logLevel">The LogLevel of this message.</param>
		/// <param name="message">The message.</param>
		public LogEventArgs(LogLevel logLevel, string message)
		{
			LogLevel = logLevel;
			Message = message;
		}
	}
}