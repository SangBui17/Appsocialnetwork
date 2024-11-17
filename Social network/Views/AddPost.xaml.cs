using Social_network.Models;
using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class AddPost : ContentPage
{
	private AddPostViewModel _viewmodel;
	public AddPost()
	{
		InitializeComponent();
		_viewmodel = new AddPostViewModel();
		BindingContext = _viewmodel;
	}
	private void OnImagesSelected(object sender, SelectionChangedEventArgs e)
	{
		var selectedImages = e.CurrentSelection.Cast<ImageResponse>().ToList();

		if (selectedImages != null && selectedImages.Count > 0)
		{
			var imageIds = selectedImages.Select(img => img.id).ToList();
			Console.WriteLine("kiemtra imageIds" + imageIds);
			var viewModel = BindingContext as AddPostViewModel;
			if (viewModel != null)
			{
				viewModel.SelectedImageIds = imageIds;
			}
		}

		// Reset selection nếu cần
		if (sender is CollectionView collectionView)
		{
			collectionView.SelectedItem = null;
		}
	}

	private void OnPrivacyOptionChanged(object sender, EventArgs e)
	{
		if (ShareOptionsPicker.SelectedIndex == -1) return;

		var selectedValue = ShareOptionsPicker.SelectedIndex; // 0 -> Công khai, 1 -> Bạn bè, 2 -> Chỉ mình tôi
		var viewModel = BindingContext as AddPostViewModel;

		if (viewModel != null)
		{
			viewModel.Privacy = selectedValue + 1; // Gán giá trị 1, 2, 3 cho privacy
		}
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewmodel.GetAddPostAsync();
	}

}