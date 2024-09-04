using Social_network.Models;
using Social_network.Services;
using Social_network.Views;

namespace Social_network;

public partial class LoginPage : ContentPage
{
	readonly LoginRepository loginrepository = new LoginService();
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void Login_Clicked(object sender, EventArgs e)
	{
		string username = txtUserName.Text.Trim();
		string password = txtPassword.Text.Trim();
		if (username == null || password == null)
		{
			DisplayAlert("warning", "Hãy nhập Username và Password", "Ok");
			return;
		}

		UserInfo userInfo = await loginrepository.Login(username, password);
		if (userInfo != null)
		{
			await Navigation.PushAsync(new HomePage());
		}

		else
		{
			await DisplayAlert("warning", "Usernam or Password is inCorrect", "ok");
		}
	}
}