using Newtonsoft.Json;
using Social_network.Models;

namespace Social_network.Response
{
    internal class FriendResponse
    {
        [JsonProperty("user_info")]

        public UserInfoResponse user_info { get; set; }
    }
}