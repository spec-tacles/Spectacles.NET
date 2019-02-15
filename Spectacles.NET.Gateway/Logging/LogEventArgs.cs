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
		/// The LogLevel of this log.
		/// </summary>
		public LogLevel LogLevel { get; }
		
		/// <summary>
		/// The message of this log.
		/// </summary>
		public string Message { get; }
		
		/// <summary>
		/// The Sender of this log, either "Cluster" or "Shard ID"
		/// </summary>
		public string Sender { get; }

		/// <inheritdoc />
		/// <summary>
		/// Creates a new instance of LogEventArgs
		/// </summary>
		/// <param name="logLevel">The LogLevel of this log.</param>
		/// <param name="message">The message of this log.</param>
		/// <param name="sender">The sender of this log</param>
		public LogEventArgs(LogLevel logLevel, string sender, string message)
		{
			LogLevel = logLevel;
			Message = message;
			Sender = sender;
		}
	}
}