using Social_network.enumtype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class NotificationPost : BaseEntity
    {
        public NotificationPostType notificationPostType { get; set; }

        public Post post { get; set; }

        public Notification notification { get; set; }
    }
}
