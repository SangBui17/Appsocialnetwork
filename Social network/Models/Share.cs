using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class Share : BaseEntity
    {
        public string content {  get; set; }

        public User user { get; set; }

        public Post post { get; set; }

        public List<NotificationFollow> notificationFollowList { get; set; }

        public List<Report> reportList { get; set; }
    }
}
