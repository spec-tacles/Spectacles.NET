using System;

namespace Spectacles.NET.Gateway.Websocket
{
	/// <inheritdoc />
	/// <summary>
	/// Event Args for the WebSocketClose event.
	/// </summary>
	public class WebSocketCloseEventArgs : EventArgs
	{
		/// <summary>
		/// The close code the connection closed with.
		/// </summary>
		public int CloseCode { get; }
		
		/// <summary>
		/// The reason this connection closed with. 
		/// </summary>
		public string Reason { get; }
		
		/// <summary>
		/// If this closed was issued by the Server.
		/// </summary>
		public bool ClosedByServer { get; }

		/// <inheritdoc />
		/// <summary>
		/// Creates a new instance of WebSocketCloseEventArgs
		/// </summary>
		/// <param name="closeCode">The close code the connection closed with.</param>
		/// <param name="reason">The reason this connection closed with.</param>
		/// <param name="closedByServer">If this closed was issued by the Server.</param>
		public WebSocketCloseEventArgs(int closeCode, string reason, bool closedByServer)
		{
			CloseCode = closeCode;
			Reason = reason;
			ClosedByServer = closedByServer;
		}
	}
}