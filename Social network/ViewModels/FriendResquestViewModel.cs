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
        public async Task GetFriendResquestAsync()
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
        public async Task RemoveFriendAsync(long userid)
        {

            // Gửi yêu cầu thêm bạn
            var result = await _friendResquestService.RemoveFriendRequest(userid);
            if (result)
            {
                ErrorMessage = "Huy kết bạn thành công.";
            }
            else
            {
                ErrorMessage = "Không thể huy kết bạn.";
            }
        }

        public async Task AddFriendAsync(long id)
        {
            try
            {
                // Gửi yêu cầu thêm bạn
                var result = await _friendResquestService.AddFriendResquest(id);
                if (result)
                {
                    ErrorMessage = "Đã gửi lời mời kết bạn thành công.";
                }
                else
                {
                    ErrorMessage = "Không thể gửi lời mời kết bạn.";
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