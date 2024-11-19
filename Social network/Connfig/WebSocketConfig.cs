using Newtonsoft.Json;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Social_network.Connfig
{
    public class WebSocketConfig
    {
        public readonly ClientWebSocket clientWebSocket;
        private readonly Uri _serverUri;

        public event Action<string> MessageReceived;
        public event Action Connected;
        public event Action Disconnected;
        private string stompClient = null;
        private int meIdinfoo;


        public WebSocketConfig(string serverUrl)
        {
            clientWebSocket = new ClientWebSocket();
            _serverUri = new Uri(serverUrl);

        }

        public async Task ConnectAsync()
        {
            try
            {
                Console.WriteLine($"Attempting to connect to WebSocket server: {_serverUri}");
                await clientWebSocket.ConnectAsync(_serverUri, CancellationToken.None);
                Connected?.Invoke();
                _ = ReceiveMessagesAsync(); // Bắt đầu nhận tin nhắn
                Console.WriteLine($"Connect successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to WebSocket: {ex.Message}");
            }
        }

        public async Task SendMessageAsync(object message)
        {
            try
            {
                var messageJson = JsonConvert.SerializeObject(message);
                var bytes = Encoding.UTF8.GetBytes(messageJson);
                await clientWebSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }

        public async Task DisconnectAsync()
        {
            try
            {
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnecting", CancellationToken.None);
                Disconnected?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disconnecting: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()   
        {
            var buffer = new byte[1024 * 4];

            while (clientWebSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        MessageReceived?.Invoke(message);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await DisconnectAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving message: {ex.Message}");
                    break;
                }
            }
        }
    }
}