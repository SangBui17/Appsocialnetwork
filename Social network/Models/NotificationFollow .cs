using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    internal class NotificationFollow : BaseEntity
    {
        public Post post {  get; set; }

        public Share share { get; set; }

        public Notification notification {  get; set; }
    }
}
