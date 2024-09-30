using IdentityModel.Client;
using Newtonsoft.Json;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class MessageResponse : BaseEntity
    {
        [JsonProperty("user_Source")]
        public UserInfoResponse userSource {  get; set; }

        [JsonProperty("user_Target")]
        public UserInfoResponse userTarget { get; set; }

        public string content { get; set; }

        public string chatId { get; set; }
    }
}
