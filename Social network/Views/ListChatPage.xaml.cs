
using Social_network.Models;
using Social_network.Response;
using Social_network.ViewModels;
using System.Collections.ObjectModel;

namespace Social_network.Views;

public partial class ListChatPage : ContentPage
{
    private MessageViewModels _viewmodel;
    private long _userTarget;
    private string _chatId;
    public ListChatPage(long userTarget)
	{
        InitializeComponent();
        _viewmodel = new MessageViewModels();
        _userTarget = userTarget;
        BindingContext = _viewmodel;

        // Đăng ký sự kiện thay đổi cho MessageList
        ((MessageViewModels)BindingContext).PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(MessageViewModels.MessageList))
            {
                ScrollToLastMessage();
            }
        };
    }

    private void ScrollToLastMessage()
    {
        // Tìm CollectionView bằng tên (nếu có) hoặc bằng BindingContext
        var collectionView = this.FindByName<CollectionView>("MessageCollectionView");
        if (collectionView != null && collectionView.ItemsSource is ObservableCollection<MessageResponse> messageList && messageList.Count > 0)
        {
            collectionView.ScrollTo(messageList[messageList.Count - 1], animate: true);
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var pageInfo = new PageInfo
        {
            index = 0,
            size = 25
        };
        //await _viewmodel.ConnectAsync(_chatId);
        // Gọi phương thức để lấy tin nhắn theo userTarget
        await _viewmodel.GetMessageforuserTaget(pageInfo, _userTarget);
        await _viewmodel.GetUserInfo();
    }
}