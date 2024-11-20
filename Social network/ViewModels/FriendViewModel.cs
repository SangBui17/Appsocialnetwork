using IdentityModel.Client;
using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Social_network.ViewModels
{
    class FriendViewModel : INotifyPropertyChanged
    {
        
        private readonly UserInfoService _userInfoService;
        private Response.UserInfoResponse _userInfoResponse;

        private readonly FriendService _friendService;
        private List<FriendResponse> _friendResponse;
        public List<FriendResponse> Friends
        {
            get => _friendResponse;
            set
            {
                _friendResponse = value;
                OnPropertyChanged(nameof(Friends)); // Notify the UI of the update
            }
        }
        public Response.UserInfoResponse UserMe
        {
            get => _userInfoResponse;
            set
            {
                _userInfoResponse = value;
                OnPropertyChanged(nameof(UserMe)); // Notify the UI of the update
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

        public FriendViewModel()
        {
            _friendService = new FriendService(new HttpClient());
            _userInfoService = new UserInfoService();
        }
        public async Task GetMeAsync()
        {
            // Fetch the messages from the service
            var userme = await _userInfoService.GetUserInfo();
            if (userme != null)
            {
                UserMe = userme; // Update the property with the fetched messages
            }
        }
        public async Task GetFriendsAsync()
        {
            try
            {
                var friends = await _friendService.GetAllFriends();
                if (friends != null)
                {
                    Friends = friends;
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
        public async Task GetFriendsIdAsync(long id)
        {
            try
            {
                var friends = await _friendService.GetAllFriendId(id);
                if (friends != null)
                {
                    Friends = friends;
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
        public async Task AddFriendAsync(long id)
        {
            try
            {
                // Gửi yêu cầu thêm bạn
                var result = await _friendService.AddFriend(id);
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
        public async Task RemoveFriendAsync(long userTarget)
        {
           
                // Gửi yêu cầu thêm bạn
                var result = await _friendService.RemoveFriend(userTarget);
                if (result)
                {   
                    ErrorMessage = "Huy kết bạn thành công.";
                }
                else
                {
                    ErrorMessage = "Không thể huy kết bạn.";
                }
        }
            
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}