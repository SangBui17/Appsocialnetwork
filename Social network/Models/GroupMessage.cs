using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class GroupMessage : BaseEntity
    {
        public List<Image> Avatars { get; set; } = new List<Image>();
        public User Author { get; set; }

        // Danh sách thành viên trong nhóm
        public List<MemberGroupMessage> MemberGroupMessageList { get; set; } = new List<MemberGroupMessage>();

        // Danh sách tin nhắn trong nhóm
        public List<ChatGroupMessage> ChatGroupMessageList { get; set; } = new List<ChatGroupMessage>();
    }
}
