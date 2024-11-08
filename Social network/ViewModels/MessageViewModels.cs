using Newtonsoft.Json;
using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Social_network.ViewModels
{
    internal class MessageViewModels : INotifyPropertyChanged
    {
        private readonly MessageService _messageService;
        private readonly UserInfoService _userInfoService;

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
                // Thêm tin nhắn mới vào MessageList và thông báo thay đổi
                MessageList.Add(messageResponse);
                OnPropertyChanged(nameof(MessageList)); // Thông báo cập nhật MessageList
                Message = string.Empty;
            }
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
