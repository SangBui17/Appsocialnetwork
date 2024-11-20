using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.request
{
    internal class PostRequest
    {
        public string content { get; set; }

        public int privacy { get; set; }

        [JsonProperty("images")]
        public List<long> images { get; set; } = new List<long>();

    }
}