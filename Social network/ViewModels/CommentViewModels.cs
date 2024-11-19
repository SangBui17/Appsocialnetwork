using Newtonsoft.Json;
using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using Social_network.ServicesImp;
using Social_network.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Social_network.ViewModels
{
    internal class CommentViewModels : INotifyPropertyChanged
    {
        private readonly CommentService _commentService;
        private ObservableCollection<CommentResponse> _commentList;

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        // Change the type to List<MessageResponse>
        public ObservableCollection<CommentResponse> CommentList
        {
            get => _commentList;
            set
            {
                _commentList = value;
                OnPropertyChanged(nameof(CommentList)); // Notify the UI of the update
            }
        }

        public CommentViewModels()
        {
            _commentService = new CommentService();
            SendCommentCommand = new Command(async () => await SendCommentAsync());
            _commentList = new ObservableCollection<CommentResponse>();
        }
        public long postId { get; set; }
        public ICommand SendCommentCommand { get; }

        private async Task SendCommentAsync()
        {
            if (string.IsNullOrWhiteSpace(Comment)) return;

            var commentRequest = new CommentRequest { content = Comment };

            var responseContent = await _commentService.addComment(commentRequest, postId);
            OnSendCommentTapped();
            if (responseContent != null)
            {
                var commentResponse = JsonConvert.DeserializeObject<CommentResponse>(responseContent);
            }
        }
        private async void OnSendCommentTapped()
        {
            // Quay lại trang trước (HomePage trong trường hợp này)
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task GetCommentAsync(PageInfo pageInfo, long id)
        {
            // Fetch the messages from the service
            var comments = await _commentService.getAllcmtByPostId(pageInfo, id);
            if (comments != null)
            {
                /*CommentList = comments; */// Update the property with the fetched messages
                CommentList.Clear();
                foreach (var msg in comments)
                {
                    CommentList.Add(msg);
                }
                postId = id;
                Debug.WriteLine($"id post: {postId}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}