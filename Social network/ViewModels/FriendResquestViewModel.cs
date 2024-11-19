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
    internal class FriendResquestViewModel : INotifyPropertyChanged
    {
        private readonly FriendResquestService _friendResquestService;
        private List<FriendRequestResponse> _friendResquestResponse;
        public List<FriendRequestResponse> FriendsResquest
        {
            get => _friendResquestResponse;
            set
            {
                _friendResquestResponse = value;
                OnPropertyChanged(nameof(FriendsResquest)); // Notify the UI of the update
            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public FriendResquestViewModel()
        {
            _friendResquestService = new FriendResquestService(new HttpClient());
        }
        public async Task GetFriendsAsync()
        {
            try
            {
                var friendresquest = await _friendResquestService.getAllFriendRequest();
                if (friendresquest != null)
                {
                    FriendsResquest = friendresquest;
                }
                else
                {
                    ErrorMessage = "Không thể tải danh sách bạn bè.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Lỗi viewmodel: {ex.Message}";
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
