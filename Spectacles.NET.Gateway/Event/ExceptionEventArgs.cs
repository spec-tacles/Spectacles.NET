using System;

namespace Spectacles.NET.Gateway.Event
{
	/// <summary>
	///     EventArgs for the ExceptionEvent
	/// </summary>
	public class ExceptionEventArgs
	{
		/// <inheritdoc />
		/// <summary>
		///     Creates a new ExceptionEventArgs instance
		/// </summary>
		/// <param name="shardID">Shard where the Dispatch occured.</param>
		/// <param name="exception">The Exception which occured.</param>
		public ExceptionEventArgs(int shardID, Exception exception)
		{
			ShardID = shardID;
			Exception = exception;
		}

		/// <summary>
		///     Shard where the Exception occured.
		/// </summary>
		public int ShardID { get; }

		/// <summary>
		///     The Exception which occured.
		/// </summary>
		public Exception Exception { get; }
	}
}
