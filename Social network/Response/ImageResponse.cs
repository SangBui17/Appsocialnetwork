using Newtonsoft.Json;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    class ImageResponse : BaseEntity
    {
        [JsonProperty("link_image")]
        public string linkImage {  get; set; }
    }
}
