using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class FriendResquestPage : ContentPage
{
    private readonly FriendViewModel _viewModelFriend;

    public FriendResquestPage()
    {
        InitializeComponent();
        _viewModelFriend = new FriendViewModel();
        BindingContext = _viewModelFriend;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModelFriend.GetFriendsAsync(); // Tải danh sách loi moi ket ban khi trang hiển thị
    }
    private async void OnAcceptButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendsPage());
    }
    private async void OnRejectButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendsPage());
    }
    //private void OnSelectionUserIdChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    // Lấy đối tượng được chọn
    //    var selectedMessage = e.CurrentSelection.FirstOrDefault() as FriendResponse;
    //    if (selectedMessage != null)
    //    {
    //        // Lấy User ID từ đối tượng
    //        var userId = selectedMessage.user_info.id;
    //        long userTarget = (long)userId;
    //        Console.WriteLine($"User ID: {userId}");
    //        Navigation.PushAsync(new ProfileUserPage(userTarget));
    //        Console.WriteLine("SelectionChanged triggered");

    //    }
    //    else if (selectedMessage == null)
    //    {
    //        Console.WriteLine("Selected item is null.");
    //        return;
    //    }
    //    else if (selectedMessage.user_info.id == null)
    //    {
    //        Console.WriteLine("User ID is null or invalid.");
    //        return;
    //    }


    //    // Reset selection (nếu bạn muốn tự động bỏ chọn sau khi xử lý)
    //    var collectionView = sender as CollectionView;
    //    collectionView.SelectedItem = null;
    //}
}