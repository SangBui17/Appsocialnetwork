using Social_network.Models;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class AddPost : ContentPage
{
	private PostViewModel _viewmodel;
	public AddPost()
	{
		InitializeComponent();
		_viewmodel = new PostViewModel();
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
		await _viewmodel.GetPostAsync(pageInfo);
	}
	// Event handler for notification icon tap
	private async void OnNotificationTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NotificationPage());
	}

}