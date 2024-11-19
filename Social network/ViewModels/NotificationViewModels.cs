using Newtonsoft.Json;
using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Social_network.ViewModels
{
    internal class NotificationViewModels : INotifyPropertyChanged
    {
        private readonly NotificationService _notificationService;
        private List<NotificationResponse> _notificationList;

        // Change the type to List<MessageResponse>
        public List<NotificationResponse> NotificationList
        {
            get => _notificationList;
            set
            {
                _notificationList = value;
                OnPropertyChanged(nameof(NotificationList)); // Notify the UI of the update
            }
        }

        public NotificationViewModels()
        {
            _notificationService = new NotificationService();
        }

        public async Task GetNotificationAsync(PageInfo pageInfo)
        {
            // Fetch the messages from the service
            var notifications = await _notificationService.getAllNotificattion(pageInfo);
            if (notifications != null)
            {
                string notifijson = JsonConvert.SerializeObject(notifications, Formatting.Indented);
                Debug.WriteLine($"thong bao: {notifijson}");
                NotificationList = notifications; // Update the property with the fetched messages
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}