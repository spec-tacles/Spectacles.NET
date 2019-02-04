using System;
using System.Collections.Generic;

namespace Spectacles.NET.Gateway.Websocket
{
	/// <summary>
	/// Options for the WebSocketClient.
	/// </summary>
	public interface IWebsocketOptions
	{
		/// <summary>
		/// The headers which should be send when connecting.
		/// </summary>
		IEnumerable<Tuple<string, string>> Headers { get; set; }
	}
}