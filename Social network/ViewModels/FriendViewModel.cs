using Social_network.Response;
using Social_network.ServicesImp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Social_network.ViewModels
{
    internal class FriendViewModel : INotifyPropertyChanged
    {
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
                var friends = await _friendService.GetAllFriendsId(id);
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}