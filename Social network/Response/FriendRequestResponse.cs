using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class FriendRequestResponse
    {
        
        [JsonProperty("user_info")]

        public UserInfoResponse userInfoResponse { get; set; }
    }
}

