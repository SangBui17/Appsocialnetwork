using Newtonsoft.Json;
using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using Social_network.ServicesImp;
using Social_network.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Social_network.ViewModels
{
	internal class AddPostViewModel : INotifyPropertyChanged
	{
		private readonly ImageService _service;
		private readonly PostService _postService;
		private List<ImageResponse> _imageList;
		private string _post;
		private List<long> _selectedImageIds = new List<long>();
		private int _privacy;
		public long imageId;
		public string PostInput
		{
			get => _post;
			set
			{
				_post = value;
				OnPropertyChanged(nameof(PostInput));
			}
		}
		
		//public List<long> SelectedImageIds
		//{
		//	get => _selectedImageIds;
		//	set
		//	{
		//		_selectedImageIds = value;
		//		OnPropertyChanged(nameof(SelectedImageIds));
		//	}
		//}
		public int Privacy
		{
			get => _privacy;
			set
			{
				_privacy = value;
				OnPropertyChanged(nameof(Privacy));
			}
		}

		public List<ImageResponse> ImageList
		{
			get => _imageList;
			set
			{
				_imageList = value;
				OnPropertyChanged(nameof(ImageList)); // Notify the UI of the update
			}
		}
		public AddPostViewModel()
		{
			_service = new ImageService();
			_postService = new PostService();
			SendPostCommand = new Command(async () => await SendPostAsync());
		}
		public ICommand SendPostCommand { get; }
		public List<long> SelectedImageIds;
		public async Task SendPostAsync()
		{
			if (string.IsNullOrWhiteSpace(PostInput)) return;
			Console.WriteLine("Check"+ SelectedImageIds);
			var postRequest = new PostRequest
			{
				content = PostInput,
				privacy = Privacy,
				ImageIds = SelectedImageIds
			};

			var responseContent = await _postService.createPost(postRequest);
			// Xử lý phản hồi từ server nếu cần
		}
		public async Task GetAddPostAsync()
		{
			// Fetch the messages from the service
			var images = await _service.getAll();
			if (images != null)
			{
				ImageList = images; // Update the property with the fetched messages
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
