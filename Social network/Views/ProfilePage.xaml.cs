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
        // tai len du lieu ca nhan va ban be
        await _viewmodel.GetMeAsync();
        await _viewmodel.GetFriendAsync();

    }
    
    // xem danh sach tat ca ban be
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
    // them bai viet
    private async void OnAddPostClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPost());
    }

    // truy cap trang ca nhan ban be
    private void OnSelectionUserIdChanged(object sender, SelectionChangedEventArgs e)
    {
        // Lấy đối tượng được chọn
        var selectedMessage = e.CurrentSelection.FirstOrDefault() as FriendResponse;
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