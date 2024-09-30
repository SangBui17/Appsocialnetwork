using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class ChatGroupMessage : BaseEntity
    {
        public string Content { get; set; }

        public MemberGroupMessage Member { get; set; }

        public GroupMessage GroupMessage { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
