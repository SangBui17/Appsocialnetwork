using Social_network.Models;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class NotificationPage : ContentPage
{
    private NotificationViewModels _viewmodel;
    public NotificationPage()
    {
        InitializeComponent();
        _viewmodel = new NotificationViewModels();
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
        await _viewmodel.GetNotificationAsync(pageInfo);
    }
}