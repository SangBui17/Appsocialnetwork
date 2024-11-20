using Extend;
using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using Social_network.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Social_network.ViewModels
{
    class ProfileViewModel : INotifyPropertyChanged
    {
        private readonly UserInfoService _userInfoService;
        private UserInfoResponse _userInfoResponse;

        private readonly PostService _postService;
        private List<PostResponse> _postResponse;

        private readonly FriendService _friendService;
        private List<FriendResponse> _friendResponse;

        private readonly LikeService _serviceLike;

        public ICommand CommentTappedCommand { get; private set; }
        public ICommand AddPostTappedCommand { get; private set; }
        public ICommand SendLikeCommand { get; private set; }

        public ProfileViewModel()
        {

            _userInfoService = new UserInfoService();
            _postService = new PostService();
            _serviceLike = new LikeService();
            _friendService = new FriendService(new HttpClient());
            CommentTappedCommand = new Command<int>(OnCommentTapped);
            SendLikeCommand = new Command<int>(SendLikeTapped);

        }
        public UserInfoResponse UserMe
        {
            get => _userInfoResponse;
            set
            {
                _userInfoResponse = value;
                OnPropertyChanged(nameof(UserMe)); // Notify the UI of the update
            }
        }
        public PageInfo PageInfo { get; }
        private async void SendLikeTapped(int postId)
        {
            // Gọi API like
            var responseContent = await _serviceLike.like(postId);

            if (responseContent != null) // Nếu API trả về phản hồi hợp lệ
            {
                // Gọi lại API để tải danh sách bài đăng mới
                //await GetPostAsync(PageInfo);
            }
        }

        private async void OnCommentTapped(int postId)
        {
            // Chuyển đến trang CommentPage và truyền postId
            await Application.Current.MainPage.Navigation.PushAsync(new CommentPage(postId));
        }

        // Change the type to List<MessageResponse>

        public List<PostResponse> PostList
        {
            get => _postResponse;
            set
            {
                _postResponse = value;
                OnPropertyChanged(nameof(PostList)); // Notify the UI of the update
            }
        }
        public List<FriendResponse> Friends
        {
            get => _friendResponse;
            set
            {
                _friendResponse = value;
                OnPropertyChanged(nameof(Friends)); // Notify the UI of the update
            }
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

        public async Task GetPostAsync(PageInfo pageInfo)
        {
            // Fetch the messages from the service
            var posts = await _postService.getAllPostByMe(pageInfo);
            if (posts != null)
            {
                PostList = posts; // Update the property with the fetched messages
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
        public async Task GetFriendAsync()
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
        public async Task GetUserByIdAsync(long id)
        {
            // Fetch the messages from the service
            var userme = await _userInfoService.GetUserById(id);
            if (userme != null)
            {
                UserMe = userme; // Update the property with the fetched messages
            }
        }
        public async Task GetPostIdAsync(PageInfo pageInfo, long id)
        {
            // Fetch the messages from the service
            var posts = await _postService.getAllPostById(pageInfo, id);
            if (posts != null)
            {
                PostList = posts; // Update the property with the fetched messages
            }
        }
        public async Task GetFriendIDAsync(long id)
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