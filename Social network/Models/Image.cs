using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Image : BaseEntity
    {
        public string LinkImage { get; set; }

        public List<User> UserAvatars { get; set; } = new List<User>();

        public List<User> UserCovers { get; set; } = new List<User>();

        public List<Post> Posts { get; set; } = new List<Post>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Message> Messages { get; set; } = new List<Message>();

        public List<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();

        public List<ChatGroupMessage> ChatGroupMessages { get; set; } = new List<ChatGroupMessage>();
    }
}
