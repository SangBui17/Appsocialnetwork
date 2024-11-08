
using Social_network.Models;
using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class ChatPage : ContentPage
{
    private MessageViewModels _viewmodel;

    private ChatPageViewModel _viewChatPageModel;

    public ChatPage()
	{
		InitializeComponent();
        _viewmodel = new MessageViewModels();
        BindingContext = _viewmodel;

        //_viewChatPageModel = new ChatPageViewModel();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var pageInfo = new PageInfo
        {
            index = 0,
            size = 5
        };
        await _viewmodel.GetMessagesAsync(pageInfo);
    }
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Lấy đối tượng được chọn
        var selectedMessage = e.CurrentSelection.FirstOrDefault() as MessageResponse;
        if (selectedMessage != null)
        {
            // Lấy User ID từ đối tượng
            var userId = selectedMessage.userTarget?.id;
            long userTarget = (long)userId;
            Console.WriteLine($"User ID: {userId}");
            // Bạn có thể thực hiện các tác vụ khác với userId ở đây
            /*var pageInfo = new PageInfo
            {
                index = 0,
                size = 5
            };
            _viewmodel.GetMessageforuserTaget(pageInfo, userTarget);*/
            Navigation.PushAsync(new ListChatPage(userTarget));
        }

        // Reset selection (nếu bạn muốn tự động bỏ chọn sau khi xử lý)
        var collectionView = sender as CollectionView;
        collectionView.SelectedItem = null;
    }

    private void OnChatTapped(object sender, EventArgs e)
    {
        // Thay đổi trạng thái hiển thị của TabBar
        TabBar.IsVisible = !TabBar.IsVisible;

        // Thêm hiệu ứng trượt nếu cần
        if (TabBar.IsVisible)
        {
            TabBar.TranslationX = -300; // Vị trí ban đầu bên trái màn hình
            TabBar.TranslateTo(0, 0, 250, Easing.Linear); // Trượt vào từ trái qua phải
        }
    }

    private void OnSettingsClicked(object sender, EventArgs e)
    {
        // X? lý s? ki?n cài ??t
        DisplayAlert("Cài ??t", "B?n ?ã nh?n vào cài ??t!", "OK");
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        // X? lý s? ki?n ??ng xu?t
        DisplayAlert("??ng xu?t", "B?n ?ã ??ng xu?t!", "OK");
    }
}