using System;

namespace Spectacles.NET.Gateway.EventArgs
{
	/// <summary>
	///     EventArgs for the ExceptionEvent
	/// </summary>
	public class ExceptionEventArgs
	{
		/// <summary>
		///     Creates a new ExceptionEventArgs instance
		/// </summary>
		/// <param name="shardId">Shard where the Dispatch occured.</param>
		/// <param name="exception">The Exception which occured.</param>
		public ExceptionEventArgs(int shardId, Exception exception)
		{
			ShardId = shardId;
			Exception = exception;
		}

		/// <summary>
		///     Shard where the Exception occured.
		/// </summary>
		public int ShardId { get; }

		/// <summary>
		///     The Exception which occured.
		/// </summary>
		public Exception Exception { get; }
	}
}
