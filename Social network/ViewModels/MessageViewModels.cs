using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Social_network.Connfig;
using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Social_network.ViewModels
{
    internal class MessageViewModels : INotifyPropertyChanged
    {
        private readonly MessageService _messageService;
        private readonly UserInfoService _userInfoService;

        private readonly WebSocketConfig _websocketConfig;
        private ObservableCollection<MessageResponse> _messageList;
        private UserInfoResponse _userInfo;

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public long UserTaget { get; set; }

        public string ChatId;

        public ObservableCollection<MessageResponse> MessageList
        {
            get => _messageList;
            set
            {
                _messageList = value;
                OnPropertyChanged(nameof(MessageList)); // Notify the UI of the update
            }
        }

        public UserInfoResponse UserInfo
        {
            get => _userInfo;
            set
            {
                _userInfo = value;
                OnPropertyChanged(nameof(UserInfo));
                OnPropertyChanged(nameof(CurrentUserId));
                Debug.WriteLine($"Fetched UserInfo: {CurrentUserId}");
            }
        }

        public long CurrentUserId => UserInfo?.id ?? 0;

        public MessageViewModels()
        {
            _messageService = new MessageService();
            _userInfoService = new UserInfoService();
            SendMessageCommand = new Command(async () => await SendMessageAsync());
            _messageList = new ObservableCollection<MessageResponse>();
            _websocketConfig = new WebSocketConfig("ws://10.0.2.2:8080/ws");
            _websocketConfig.Connected += OnConnected;
            _websocketConfig.Disconnected += OnDisconnected;
        }
        public async Task Connect()
        {
            try
            {
                var token = await SecureStorage.Default.GetAsync("access_token");
                // Kiểm tra token có hợp lệ hay không
                if (string.IsNullOrEmpty(token))
                {
                    Console.WriteLine("Error: Authentication token is missing. Cannot connect to WebSocket.");
                    return;
                }
                await _websocketConfig.ConnectAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error connect message: {ex.Message}");
            }
        }
        public async Task OnMessageReceived(string message)
        {
            try
            {
                // Split header và body
                var parts = message.Split(new[] { "\n\n" }, 2, StringSplitOptions.None);
                if (parts.Length < 2) return;

                var body = parts[1].TrimEnd('\u0000');
                var parsedMessage = JsonConvert.DeserializeObject<MessageResponse>(message);
                if (parsedMessage != null && !string.IsNullOrEmpty(parsedMessage.content))
                {
                    MessageList.Clear();
                    foreach (var msg in message)
                    {
                        MessageList.Add(parsedMessage);
                    }
                    Console.WriteLine($"Tin nhắn nhận được từ server: {parsedMessage.content}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error parsing message: {ex.Message}");
            }
        }

        private void OnConnected()
        {
            Console.WriteLine("WebSocket connected.");
        }

        private void OnDisconnected()
        {
            Console.WriteLine("WebSocket disconnected.");
        }

        public async Task ConnectAsync(string chatId)
        {
            if (_websocketConfig.clientWebSocket == null || _websocketConfig.clientWebSocket.State != WebSocketState.Open)
            {
                await Connect();
            }
            Console.WriteLine("dc ko:" + chatId);
            if (!string.IsNullOrEmpty(chatId) || _websocketConfig.clientWebSocket.State == WebSocketState.Open)
            {
                await _websocketConfig.ConnectAsync();
                // Subscribe tới topic "/user/{chatId}/private"
                string subscribeMessage = $"SUBSCRIBE\n" +
                                $"id:sub-{Guid.NewGuid()}\n" +
                                $"destination:/user/{chatId}/private\n" +
                                $"ack:auto\n\n\u0000"; // Dòng trống để kết thúc phần header trước ký tự NULL
                var bytes = Encoding.UTF8.GetBytes(subscribeMessage);
                await _websocketConfig.clientWebSocket.SendAsync(
                    new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None
                );
                Console.WriteLine($"Subscribed to /user/{chatId}/private");
            }
            else
            {
                Console.WriteLine("WebSocket không được kết nối.");
            }
        }

        public ICommand SendMessageCommand { get; }
        private async Task SendMessageAsync()
        {
            if (string.IsNullOrWhiteSpace(Message)) return;

            var messageRequest = new MessageRequest { content = Message };

            var responseContent = await _messageService.creatMessage(messageRequest, UserTaget.ToString());
            if (responseContent != null)
            {
                var messageResponse = JsonConvert.DeserializeObject<MessageResponse>(responseContent);
                var messageResponseString = JsonConvert.SerializeObject(messageResponse);
                // Thêm tin nhắn mới vào MessageList và thông báo thay đổi
                MessageList.Add(messageResponse);
                OnPropertyChanged(nameof(MessageList)); // Thông báo cập nhật MessageList
                Message = string.Empty;

                // Định dạng tin nhắn theo giao thức STOMP
                var messageToSend = $@"
                SEND
                destination:/user/{ChatId}/private
                content-type:application/json

                {JsonConvert.SerializeObject(messageResponse)}
                \u0000";

                Console.WriteLine($"Send to /user/{ChatId}/private");

                await _websocketConfig.SendMessageAsync(messageToSend);
                await OnMessageReceived(messageResponseString);
                // Log gửi qua WebSocket
                Console.WriteLine($"WebSocket gửi tới /user/{ChatId}/private với nội dung: {messageToSend}");
            }
        }


        public async Task DisconnectAsync()
        {
            await _websocketConfig.DisconnectAsync();
        }


        public async Task GetMessagesAsync(PageInfo pageInfo)
        {
            var messages = await _messageService.getAlluserMessageByme(pageInfo);
            if (messages != null)
            {
                MessageList.Clear();
                foreach (var msg in messages)
                {
                    MessageList.Add(msg);
                }
            }
        }

        public async Task GetMessageforuserTaget(PageInfo pageInfo, long userTaget)
        {
            var message = await _messageService.getAllMessageByMeAndUserId(pageInfo, userTaget);
            if (message != null)
            {
                MessageList.Clear();
                foreach (var msg in message)
                {
                    MessageList.Add(msg);
                }
                UserTaget = userTaget;
                Debug.WriteLine($"id người nhận: {UserTaget}");
                ChatId = MessageList?.FirstOrDefault()?.chatId ?? string.Empty;
                ConnectAsync(ChatId);

            }
            else
            {
                Debug.WriteLine("No messages found");
            }
        }

        public async Task GetUserInfo()
        {
            var userInfome = await _userInfoService.GetUserInfo();
            if (userInfome != null)
            {
                string userInfoJson = JsonConvert.SerializeObject(userInfome, Formatting.Indented);
                Debug.WriteLine($"Fetched UserInfo: {userInfoJson}");
                UserInfo = userInfome;
            }
            else
            {
                Debug.WriteLine("No userinfo found");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}