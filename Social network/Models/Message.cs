using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Message :BaseEntity
    {
        public string Content { get; set; }

        public User UserSource { get; set; }

        public User UserTarget { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();

        public string ChatId { get; set; }
    }
}
