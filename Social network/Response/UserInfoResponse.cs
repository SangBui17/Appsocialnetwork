using Newtonsoft.Json;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Social_network.Response
{
    class UserInfoResponse : BaseEntity
    {
        public string username { get; set; }

        public bool gender {  get; set; }

        [JsonProperty("last_name")]

        public string lastName { get; set; }

        [JsonProperty("first_name")]

        public string firstName { get; set; }

        public string fullName => $"{lastName} {firstName}";

        [JsonProperty("dob")]

        public DateTime dob { get; set; }

        [JsonProperty("bio")]

        public string bio { get; set; }

        public ImageResponse avatar_image { get; set; }

        public ImageResponse cover_image { get; set; }

        [JsonProperty("hometown")]

        public AddressResponse homeTown { get; set; }

        [JsonProperty("current_city")]

        public AddressResponse currentCity { get; set; }
    }
}
