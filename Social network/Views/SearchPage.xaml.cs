using Social_network.Response;
using Social_network.ViewModels;

namespace Social_network.Views;

public partial class SearchPage: ContentPage
{
	private readonly SearchViewModel _searchViewModel;
	public SearchPage()
	{
        InitializeComponent();
		_searchViewModel = new SearchViewModel();
		BindingContext = _searchViewModel;
    }
    private async void OnSearchCompleted(object sender, EventArgs e)
    {
        // Lấy nội dung từ Entry
        var entry = sender as Entry;
        string searchText = entry?.Text;

        // Xử lý logic tìm kiếm
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            await _searchViewModel.FindByUsername(searchText);
        }
    }

    private void OnSelectionUserIdChangedd(object sender, SelectionChangedEventArgs e)
    {
        // Lấy đối tượng được chọn
        var selectedMessage = e.CurrentSelection.FirstOrDefault() as UserInfoResponse;
        if (selectedMessage != null)
        {
            // Lấy User ID từ đối tượng
            var userId = selectedMessage.id;
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
        else if (selectedMessage.id == null)
        {
            Console.WriteLine("User ID is null or invalid.");
            return;
        }


        // Reset selection (nếu bạn muốn tự động bỏ chọn sau khi xử lý)
        var collectionView = sender as CollectionView;
        collectionView.SelectedItem = null;
    }
}