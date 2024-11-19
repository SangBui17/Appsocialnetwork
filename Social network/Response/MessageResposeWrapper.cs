using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class MessageResposeWrapper
    {
        [JsonProperty("content")]
        public List<MessageResponse> content {  get; set; }

    }
}
