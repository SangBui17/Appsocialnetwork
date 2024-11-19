using Social_network.enumtype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Social_network.Models
{
    internal class Notification : BaseEntity
    {
        public Date createdDate {  get; set; }
        public string content { get; set; }

        public User user { get; set; }

        public NotificationSeenType  status { get; set; }

        private NotificationPost notificationPost { get; set; }

        private NotificationFollow notificationFollow { get; set; }
    }
}
