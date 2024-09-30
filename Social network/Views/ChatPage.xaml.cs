
using Social_network.Models;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class ChatPage : ContentPage
{
    private MessageViewModels _viewmodel;

    public ChatPage()
	{
		InitializeComponent();
        _viewmodel = new MessageViewModels();
        BindingContext = _viewmodel;

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
    private void OnChatTapped(object sender, EventArgs e)
    {
        TabBar.IsVisible = !TabBar.IsVisible; // Hi?n/?n thanh tab bar
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