using IdentityModel.Client;
using Social_network.Models;
using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class ProfileUserPage : ContentPage
{

    private ProfileViewModel _viewmodel;
    private Response.UserInfoResponse _viewId;
    private long _userTarget;

    public ProfileUserPage(long userid)
    {
        InitializeComponent();
        _viewmodel = new ProfileViewModel();
        _viewId = new Response.UserInfoResponse();
        BindingContext = _viewmodel;
        _userTarget = userid;

        LoadUserData();
    }

    private async void LoadUserData()
    {

        await _viewmodel.GetUserByIdAsync(_userTarget);
        await _viewmodel.GetFriendIDAsync(_userTarget);

    }
    private async void OnMessageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChatPage());
    }
    private async void OnFriendsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FriendUserPage(_userTarget));
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var pageInfo = new PageInfo
        {
            index = 0,
            size = 5
        };
        await _viewmodel.GetPostIdAsync(pageInfo, _userTarget);
    }
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
            Console.WriteLine($"ID: {_viewId.id}");
            Console.WriteLine($"ID target: {_userTarget}");

            if(userId == _viewId.id)
            {
            Navigation.PushAsync(new ProfilePage());
            }
            else
            {
                Navigation.PushAsync(new ProfileUserPage(userTarget));
            }
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
    }
}