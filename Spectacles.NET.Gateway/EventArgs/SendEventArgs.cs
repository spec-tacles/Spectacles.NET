using System;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway.EventArgs
{
	/// <summary>
	///     EventArgs for the SendEvent
	/// </summary>
	public class SendEventArgs : System.EventArgs
	{
		/// <summary>
		/// </summary>
		/// <param name="shardId">Shard where the Packet was sent.</param>
		/// <param name="data">Data of the Dispatch.</param>
		/// <param name="opCode">The OPCode of this Dispatch.</param>
		public SendEventArgs(int shardId, OpCode opCode, object data)
		{
			ShardId = shardId;
			OpCode = opCode;
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		///     Shard where the Dispatch occured.
		/// </summary>
		public int ShardId { get; }

		/// <summary>
		///     The OpCode of this Packet
		/// </summary>
		public OpCode OpCode { get; }

		/// <summary>
		///     The Data of this Packet
		/// </summary>
		public object Data { get; }
	}
}
