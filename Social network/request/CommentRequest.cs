using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.request
{
    internal class CommentRequest
    {
        public string content {  get; set; }

		[JsonProperty("image_id")]
		public long imageId { get; set; }
	}
}
