using Social_network.Models;
using Social_network.Response;
using Social_network.ServicesImp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.ViewModels
{
    internal class SearchViewModel
    {
        private readonly UserInfoService userInfoService;
        private ObservableCollection<UserInfoResponse> userInfoResponse;
        private bool isResultVisible;

        public ObservableCollection<UserInfoResponse> Userinfo
        {
            get => userInfoResponse;
            set
            {
                userInfoResponse = value;
                OnPropertyChanged(nameof(Userinfo)); // Notify the UI of the update
            }
        }
        public bool IsResultVisible
        {
            get => isResultVisible;
            set
            {
                isResultVisible = value;
                OnPropertyChanged(nameof(IsResultVisible)); // Notify the UI of changes
            }
        }
        public SearchViewModel()
        {
            userInfoService = new UserInfoService();
            userInfoResponse = new ObservableCollection<UserInfoResponse>();
            IsResultVisible = false;
        }

        public async Task FindByUsername(string username)
        {
            var user = await userInfoService.FindByUsername(username);
            if (user != null)
            {
                Userinfo.Clear();
                Userinfo.Add(user);
                OnPropertyChanged(nameof(Userinfo));
                IsResultVisible = true; // Show results
            }
            else
            {
                IsResultVisible = false; // Hide results if no user is found
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
