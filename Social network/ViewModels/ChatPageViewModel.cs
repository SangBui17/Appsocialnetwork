using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.ViewModels
{
    class ChatPageViewModel : INotifyPropertyChanged
    {
        private readonly MessageService messageService;
        private List<MessageResponse> _messageList;
        public List<MessageResponse> ContentMessageList
        {
            get => _messageList;
            set
            {
                _messageList = value;
                OnPropertyChanged(nameof(ContentMessageList));
            }
        }

        public async Task GetMessageforuserTaget(PageInfo pageInfo, long userTaget)
        {
            var message = await messageService.getAllMessageByMeAndUserId(pageInfo, userTaget);
            if (message != null)
            {
                ContentMessageList = message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
