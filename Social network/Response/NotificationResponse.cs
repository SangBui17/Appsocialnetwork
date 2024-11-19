using Newtonsoft.Json;
using Social_network.enumtype;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class NotificationResponse : BaseEntity
    {
        public string content { get; set; }

        public NotificationSeenType status { get; set; }
        public DateTime created_date { get; set; }

        [JsonProperty("notification_post")]

        public NotificationPostResponse notificationPostResponse { get; set; }

        [JsonProperty("notification_follow")]

        public NotificationFollowResponse notificationFollowResponse { get; set; }

    }
}