using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class MemberGroupMessage : BaseEntity
    {
        public User User { get; set; }

        // Danh sách nhóm mà thành viên thuộc về
        public GroupMessage GroupMessage { get; set; }

        public bool IsAdmin { get; set; }

        // Danh sách tin nhắn trong nhóm
        public List<ChatGroupMessage> ChatGroupMessageList { get; set; } = new List<ChatGroupMessage>();
    }
}
