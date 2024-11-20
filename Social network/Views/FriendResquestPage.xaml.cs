using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class FriendResquestPage : ContentPage
{
    private readonly FriendResquestViewModel _viewModelFriendResquest;

    public FriendResquestPage()
    {
        InitializeComponent();
        _viewModelFriendResquest = new FriendResquestViewModel();
        BindingContext = _viewModelFriendResquest;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModelFriendResquest.GetFriendResquestAsync(); // Tải danh sách loi moi ket ban khi trang hiển thị
    }
    private async void OnAcceptButtonClicked(object sender, EventArgs e)
    {
        // Lấy Button đã được nhấn
        if (sender is Button button && button.BindingContext is FriendRequestResponse selectedMessage)
        {
            // Lấy User ID từ BindingContext
            var userId = selectedMessage.user_info.id;
            long userTarget = (long)userId;
            Console.WriteLine($"adding Friend ID: {userTarget}");

            // Gọi hàm xóa bạn bè
            _viewModelFriendResquest.AddFriendAsync(userTarget);

            Console.WriteLine("Friend added successfully.");
        }
    }
    private async void OnRejectButtonClicked(object sender, EventArgs e)
    {
        // Lấy Button đã được nhấn
        if (sender is Button button && button.BindingContext is FriendRequestResponse selectedMessage)
        {
            // Lấy User ID từ BindingContext
            var userId = selectedMessage.user_info.id;
            long userTarget = (long)userId;
            Console.WriteLine($"Deleting Friend ID: {userTarget}");

            // Gọi hàm xóa bạn bè
            _viewModelFriendResquest.RemoveFriendAsync(userTarget);

            Console.WriteLine("Friend deleted successfully.");
        }
    }


    private void OnSelectionUserIdChanged(object sender, SelectionChangedEventArgs e)
    {
        // Lấy đối tượng được chọn
        var selectedMessage = e.CurrentSelection.FirstOrDefault() as FriendRequestResponse;
        if (selectedMessage != null)
        {
            // Lấy User ID từ đối tượng
            var userId = selectedMessage.user_info.id;
            long userTarget = (long)userId;
            Console.WriteLine($"User ID: {userId}");
            Navigation.PushAsync(new ProfileUserPage(userTarget));
            Console.WriteLine("SelectionChanged triggered");

        }
        else if (selectedMessage == null)
        {
            Console.WriteLine("Selected item is null.");
            return;
        }
        else if (selectedMessage.user_info.id == null)
        {
            Console.WriteLine("User ID is null or invalid.");
            return;
        }


        // Reset selection (nếu bạn muốn tự động bỏ chọn sau khi xử lý)
        var collectionView = sender as CollectionView;
        collectionView.SelectedItem = null;
    }
}