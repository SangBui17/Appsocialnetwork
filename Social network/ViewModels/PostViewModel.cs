using Newtonsoft.Json;
using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using Social_network.ServicesImp;
using Social_network.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Social_network.ViewModels
{
	internal class PostViewModel : INotifyPropertyChanged
	{

		private readonly PostService _service;
		private readonly LikeService _serviceLike;

		private List<PostResponse> _postList;
		public ICommand CommentTappedCommand { get; private set; }
		public ICommand SendLikeCommand { get; private set; }
		// Change the type to List<MessageResponse>
		public List<PostResponse> PostList
		{
			get => _postList;
			set
			{
				_postList = value;
				OnPropertyChanged(nameof(PostList)); // Notify the UI of the update
			}
		}
		public PostViewModel()
		{
			_service = new PostService();
			_serviceLike = new LikeService();
			// Khởi tạo lệnh cho khi nhấn vào bình luận
			CommentTappedCommand = new Command<int>(OnCommentTapped);
			SendLikeCommand = new Command<int>(SendLikeTapped);
		}

		private async void SendLikeTapped(int postId)
		{
			var responseContent = await _serviceLike.like(postId);
		}

		private async void OnCommentTapped(int postId)
		{
			// Chuyển đến trang CommentPage và truyền postId
			await Application.Current.MainPage.Navigation.PushAsync(new CommentPage(postId));
		}
		public async Task GetPostAsync(PageInfo pageInfo)
		{
			// Fetch the messages from the service
			var posts = await _service.getAllPost(pageInfo);
			if (posts != null)
			{
				PostList = posts; // Update the property with the fetched messages
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
