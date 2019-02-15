using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spectacles.NET.Gateway.Websocket
{
	/// <inheritdoc />
	/// <summary>
	/// A Basic Client for handling WebSocket Connections.
	/// </summary>
	public class WebSocketClient : IDisposable
	{
		/// <summary>
		/// Event emitted when the WebSocket Connection Closes.
		/// </summary>
		public event EventHandler<WebSocketCloseEventArgs> Close;
		
		/// <summary>
		/// Event emitted if the Connection encounters issues.
		/// </summary>
		public event EventHandler<Exception> Error;
		
		/// <summary>
		/// Event emitted if the WebSocket receive a Text Message.
		/// </summary>
		public event EventHandler<string> Message;
		
		/// <summary>
		/// Event emitted if the WebSocket receive Binary Data.
		/// </summary>
		public event EventHandler<byte[]> Data;
		
		/// <summary>
		/// Event emitted when the WebSocket Connection open.
		/// </summary>
		public event EventHandler Open;

		/// <summary>
		/// The State of the WebSocket Connection.
		/// </summary>
		public WebSocketState Status => _ws.State;
		
		/// <summary>
		/// The CancellationToken of this WebSocketClient.
		/// </summary>
		private readonly CancellationToken _cancellationToken = new CancellationTokenSource().Token;
		
		/// <summary>
		/// The ClientWebSocket of this WebSocketClient.
		/// </summary>
		private readonly ClientWebSocket _ws = new ClientWebSocket();
		
		/// <summary>
		/// If the ReadThread should be exited.
		/// </summary>
		private bool _exit;
		
		/// <summary>
		/// The ReadThread of this WebSocketClient
		/// </summary>
		private Thread _readThread;
		
		/// <summary>
		/// The URI this WebSocketClient should connect.
		/// </summary>
		private readonly Uri _uri;
		
		/// <summary>
		/// If this WebSocketClient is disposed.
		/// </summary>
		private bool _disposed;
		
		/// <summary>
		/// Creates a new instance of WebSocketClient.
		/// </summary>
		/// <param name="url">The URL this WebSocketClient should connect to.</param>
		/// <param name="options">Options of this WebSocketClient.</param>
		public WebSocketClient(string url, IWebsocketOptions options)
		{
			_uri = new Uri(url);

			if (options?.Headers == null) return;
			foreach (var (item1, item2) in options.Headers)
			{
				_ws.Options.SetRequestHeader(item1, item2);
			}
		}

		/// <summary>
		/// Connects this WebSocketClient to the WebSocket Server.
		/// </summary>
		/// <returns>Task.</returns>
		/// <exception cref="Exception">If the WebSocket Connection is already Connected or Connecting.</exception>
		public async Task ConnectAsync()
		{
			if (Status == WebSocketState.Open || Status == WebSocketState.Connecting) throw new Exception("Websocket already Connected or Connecting");
			await _ws.ConnectAsync(_uri, _cancellationToken);
			_exit = false;
			Open?.Invoke(this, EventArgs.Empty);
			_readThread = new Thread(_listen);
			_readThread.Start();
		}

		/// <summary>
		/// Sends Data to the WebSocket Server.
		/// </summary>
		/// <param name="data">The data to send to.</param>
		/// <returns>Task</returns>
		/// <exception cref="Exception">If The Connection is Closed.</exception>
		public async Task SendAsync(byte[] data)
		{
			if (Status == WebSocketState.Closed) throw new Exception("Cannot Send a Message to a Closed Connection");
			await _ws.SendAsync(data, WebSocketMessageType.Text, true, _cancellationToken);
		}

		/// <summary>
		/// Sends Data to the WebSocket Server.
		/// </summary>
		/// <param name="data">The data to send to.</param>
		/// <returns>Task</returns>
		/// <exception cref="Exception">If The Connection is Closed.</exception>
		public Task SendAsync(string data)
			=> SendAsync(Encoding.UTF8.GetBytes(data));

		/// <summary>
		/// Closes the Connection to the WebSocket Server.
		/// </summary>
		/// <param name="closeStatus">The Status this Connection should be closed with.</param>
		/// <param name="closeText">The Status text this Connection should be closed with.</param>
		/// <returns>Task</returns>
		/// <exception cref="Exception">If the Connection is already Closed</exception>
		public async Task CloseAsync(WebSocketCloseStatus closeStatus, string closeText)
		{
			if (Status == WebSocketState.Closed) throw new Exception("Websocket already Closed");
			_exit = true;
			await _ws.CloseAsync(closeStatus, closeText, _cancellationToken);
			Close?.Invoke(this, new WebSocketCloseEventArgs((int) closeStatus, closeText, false));
		}

		/// <summary>
		/// Continuously reading from the WebSocket Connection.
		/// </summary>
		private async void _listen()
		{
			while (_ws.State == WebSocketState.Open)
			{
				var message = "";
				var binary = new List<byte>();
				
				READ:
				if (_exit) return;
				
				
				var buffer = new byte[16 * 1024];
				WebSocketReceiveResult res;
				try
				{
					res = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationToken);
				}
				catch (Exception e)
				{
					Error?.Invoke(this, e);
					break;
				}
				
				if (res == null)
					goto READ;
				
				// ReSharper disable once SwitchStatementMissingSomeCases
				switch (res.MessageType)
				{
					case WebSocketMessageType.Close:
						if (_ws.CloseStatus != null)
							Close?.Invoke(this,
								new WebSocketCloseEventArgs((int) _ws.CloseStatus, _ws.CloseStatusDescription, true));
						return;
					case WebSocketMessageType.Text:
					{
						if (!res.EndOfMessage)
						{
							message += Encoding.UTF8.GetString(buffer).TrimEnd('\0');
							goto READ;
						}
						message += Encoding.UTF8.GetString(buffer).TrimEnd('\0');

						if (message.Trim() == "ping")
							try
							{
								await _ws.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), WebSocketMessageType.Text, true, _cancellationToken);
							}
							catch (Exception e)
							{
								Error?.Invoke(this, e);
								return;
							}
						else
						{
							Message?.Invoke(this, message);
						}
						break;
					}
					case WebSocketMessageType.Binary:
						var exactDataBuffer = new byte[res.Count];
						Array.Copy(buffer, 0, exactDataBuffer, 0, res.Count);
						if (!res.EndOfMessage)
						{
							binary.AddRange(exactDataBuffer);
							goto READ;
						}

						binary.AddRange(exactDataBuffer);
						var binaryData = binary.ToArray();
						Data?.Invoke(this, binaryData);
						break;
				}
			}

			if (_ws.State == WebSocketState.Closed || _ws.State == WebSocketState.CloseReceived || _exit) return;
			if (_ws.CloseStatus != null)
				Close?.Invoke(this,
					new WebSocketCloseEventArgs((int) _ws.CloseStatus.Value, _ws.CloseStatusDescription, true));
		}

		/// <inheritdoc />
		public void Dispose()
		{
			if (_disposed) return;
			_ws?.Abort();
			_ws?.Dispose();
			_disposed = true;
		}
	}
}