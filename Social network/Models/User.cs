using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } // Thay đổi Boolean thành bool
        public bool Gender { get; set; } // Thay đổi Boolean thành bool
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Dob { get; set; } // Đổi DateAndTime thành DateTime
        public string Bio { get; set; }
        public Address HomeTown { get; set; }
        public Address CurrentCity { get; set; }

        public List<Image> AvatarImages { get; set; } = new List<Image>();
        private List<Image> CoverImages { get; set; } = new List<Image>();
        private List<Friend> Friends { get; set; } = new List<Friend>();
        private List<FriendRequest> FriendRequests { get; set; } = new List<FriendRequest>();
        private List<Role> Roles { get; set; } = new List<Role>();
        private List<Post> Posts { get; set; } = new List<Post>();
        private List<Follower> Followers { get; set; } = new List<Follower>();
        private List<Following> Followings { get; set; } = new List<Following>();
        private List<Like> Likes { get; set; } = new List<Like>();
        private List<Share> Shares { get; set; } = new List<Share>();
        private List<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
        private List<GroupMessage> GroupMessageList { get; set; } = new List<GroupMessage>();
        private List<Notification> Notifications { get; set; } = new List<Notification>();
        private List<Report> Reports { get; set; } = new List<Report>();
        private List<Browser> Browsers { get; set; } = new List<Browser>();
    }
}
