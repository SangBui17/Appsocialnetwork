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
        // Services
        private readonly UserInfoService _userInfoService;
        private readonly PostService _postService;
        private readonly FriendService _friendService;
        private readonly LikeService _likeService;

        // Fields
        private UserInfoResponse _userInfoResponse;
        private List<PostResponse> _postResponse;
        private List<FriendResponse> _friendResponse;
        private string _errorMessage;

        // Commands
        public ICommand CommentTappedCommand { get; }
        public ICommand SendLikeCommand { get; }

        // Constructor
        public ProfileViewModel()
        {
            _userInfoService = new UserInfoService();
            _postService = new PostService();
            _friendService = new FriendService(new HttpClient());
            _likeService = new LikeService();

            CommentTappedCommand = new Command<int>(OnCommentTapped);
            SendLikeCommand = new Command<int>(OnSendLikeTapped);
        }

        // Properties
        public UserInfoResponse UserMe
        {
            get => _userInfoResponse;
            set
            {
                _userInfoResponse = value;
                OnPropertyChanged(nameof(UserMe));
            }
        }

        public List<PostResponse> PostList
        {
            get => _postResponse;
            set
            {
                _postResponse = value;
                OnPropertyChanged(nameof(PostList));
            }
        }

        public List<FriendResponse> Friends
        {
            get => _friendResponse;
            set
            {
                _friendResponse = value;
                OnPropertyChanged(nameof(Friends));
                OnPropertyChanged(nameof(LimitedFriends)); // Update LimitedFriends
            }
        }

        public IEnumerable<FriendResponse> LimitedFriends => Friends?.Take(3) ?? Enumerable.Empty<FriendResponse>();

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        // Methods

        // Fetch user info
        public async Task GetMeAsync()
        {
            var userInfo = await _userInfoService.GetUserInfo();
            if (userInfo != null)
            {
                UserMe = userInfo;
            }
        }

        // Fetch posts by current user
        public async Task GetPostAsync(PageInfo pageInfo)
        {
            var posts = await _postService.getAllPostByMe(pageInfo);
            if (posts != null)
            {
                PostList = posts;
            }
        }

        // Fetch friends of current user
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
                ErrorMessage = $"Lỗi tải bạn bè: {ex.Message}";
            }
        }

        // Fetch user info by ID
        public async Task GetUserByIdAsync(long id)
        {
            var userInfo = await _userInfoService.GetUserById(id);
            if (userInfo != null)
            {
                UserMe = userInfo;
            }
        }

        // Fetch posts by user ID
        public async Task GetPostIdAsync(PageInfo pageInfo, long id)
        {
            var posts = await _postService.getAllPostById(pageInfo, id);
            if (posts != null)
            {
                PostList = posts;
            }
        }

        // Fetch friends by user ID
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
                ErrorMessage = $"Lỗi tải bạn bè: {ex.Message}";
            }
        }

        // Add friend
        public async Task AddFriendAsync(long id)
        {
            try
            {
                var result = await _friendService.AddFriend(id);
                ErrorMessage = result
                    ? "Đã gửi lời mời kết bạn thành công."
                    : "Không thể gửi lời mời kết bạn.";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Lỗi thêm bạn: {ex.Message}";
            }
        }

        // Remove friend
        public async Task RemoveFriendAsync(long id)
        {
            try
            {
                var result = await _friendService.RemoveFriend(id);
                ErrorMessage = result
                    ? "Hủy kết bạn thành công."
                    : "Không thể hủy kết bạn.";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Lỗi hủy bạn: {ex.Message}";
            }
        }

        // Handle like action
        private async void OnSendLikeTapped(int postId)
        {
            var response = await _likeService.like(postId);
            if (response != null)
            {
                ErrorMessage = "Đã thích bài viết.";
                // Optionally reload posts
                // await GetPostAsync(PageInfo);
            }
        }

        // Handle comment action
        private async void OnCommentTapped(int postId)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CommentPage(postId));
        }

        // PropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
