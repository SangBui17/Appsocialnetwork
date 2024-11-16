using Social_network.Models;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class CommentPage : ContentPage
{
	private CommentViewModels _viewmodel;
	private long _postId;
	public CommentPage(long postId)
	{
		InitializeComponent();
		_postId = postId;
		_viewmodel = new CommentViewModels();
		BindingContext = _viewmodel;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var id = _postId;
		var pageInfo = new PageInfo
		{
			index = 0,
			size = 10
		};
		await _viewmodel.GetCommentAsync(pageInfo, id);
	}
}