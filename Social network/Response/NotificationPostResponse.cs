using Newtonsoft.Json;
using Social_network.enumtype;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class NotificationPostResponse : BaseEntity
    {
        [JsonProperty("notification_post_type")]

        public NotificationPostType notificationPostType { get; set; }

        [JsonProperty("post_id")]

        public long postId { get; set; }

        public string? avatar { get; set; }
    }
}