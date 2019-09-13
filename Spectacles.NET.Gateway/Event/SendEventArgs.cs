using System;
using Spectacles.NET.Types;

namespace Spectacles.NET.Gateway.Event
{
	/// <summary>
	///     EventArgs for the SendEvent
	/// </summary>
	public class SendEventArgs : EventArgs
	{
		/// <summary>
		/// </summary>
		/// <param name="shardID">Shard where the Packet was sent.</param>
		/// <param name="data">Data of the Dispatch.</param>
		/// <param name="opCode">The OPCode of this Dispatch.</param>
		public SendEventArgs(int shardID, OpCode opCode, object data)
		{
			ShardID = shardID;
			OpCode = opCode;
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		///     Shard where the Dispatch occured.
		/// </summary>
		public int ShardID { get; }

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
