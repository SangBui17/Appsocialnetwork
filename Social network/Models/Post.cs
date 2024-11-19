
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Post : BaseEntity
    {
        public User Author { get; set; } // Thay đổi thành public nếu cần truy cập bên ngoài
        public string Content { get; set; }
        public int Privacy { get; set; } // 1 - công khai, 2 - bạn bè, 3 - chỉ mình tôi

        // Xóa tất cả comment khi xóa post
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Share> Shares { get; set; } = new List<Share>();
        public List<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
        public List<NotificationPost> NotificationPostList { get; set; } = new List<NotificationPost>();
        public List<NotificationFollow> NotificationFollowList { get; set; } = new List<NotificationFollow>();
        public List<Report> ReportList { get; set; } = new List<Report>();
    }
}
