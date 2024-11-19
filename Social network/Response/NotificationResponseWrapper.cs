using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class NotificationResponseWrapper
    {
        [JsonProperty("content")]
        public List<NotificationResponse> content { get; set; }
    }
}