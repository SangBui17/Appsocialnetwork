using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.ViewModels
{
    internal class MessageViewModels : INotifyPropertyChanged
    {
        private readonly MessageService _messageService;
        private List<MessageResponse> _messageList;

        // Change the type to List<MessageResponse>
        public List<MessageResponse> MessageList
        {
            get => _messageList;
            set
            {
                _messageList = value;
                OnPropertyChanged(nameof(MessageList)); // Notify the UI of the update
            }
        }

        public MessageViewModels()
        {
            _messageService = new MessageService();
        }

        public async Task GetMessagesAsync(PageInfo pageInfo)
        {
            // Fetch the messages from the service
            var messages = await _messageService.getAlluserMessageByme(pageInfo);
            if (messages != null)
            {
                MessageList = messages; // Update the property with the fetched messages
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
