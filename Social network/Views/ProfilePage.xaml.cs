using Social_network.Models;
using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class ProfilePage : ContentPage
{
    private ProfileViewModel _viewmodel;

    public ProfilePage()
    {
        InitializeComponent();
        _viewmodel = new ProfileViewModel();
        BindingContext = _viewmodel;

        LoadUserData();
    }

    private async void LoadUserData()
    {
        // Tải dữ liệu cá nhân và danh sách bạn bè
        await _viewmodel.GetMeAsync();
        await _viewmodel.GetFriendAsync();
    }

    // Hiển thị danh sách tất cả bạn bè
    private async void OnFriendsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendsPage());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var pageInfo = new PageInfo
        {
            index = 0,
            size = 5
        };
        await _viewmodel.GetPostAsync(pageInfo);
    }

    // Thêm bài viết
    private async void OnAddPostClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPost());
    }

    // Truy cập trang cá nhân của bạn bè
    private void OnSelectionUserIdChanged(object sender, SelectionChangedEventArgs e)
    {
        // Lấy đối tượng được chọn
        var selectedFriend = e.CurrentSelection.FirstOrDefault() as FriendResponse;
        if (selectedFriend != null)
        {
            // Lấy User ID từ đối tượng
            var userId = selectedFriend.user_info.id;
            if (userId != null)
            {
                long userTarget = (long)userId;
                Console.WriteLine($"User ID: {userId}");
                Navigation.PushAsync(new ProfileUserPage(userTarget));
                Console.WriteLine("SelectionChanged triggered");
            }
            else
            {
                Console.WriteLine("User ID is null or invalid.");
            }
        }
        else
        {
            Console.WriteLine("Selected item is null.");
        }

        // Reset selection (nếu bạn muốn tự động bỏ chọn sau khi xử lý)
        var collectionView = sender as CollectionView;
        if (collectionView != null)
        {
            collectionView.SelectedItem = null;
        }
    }
}
