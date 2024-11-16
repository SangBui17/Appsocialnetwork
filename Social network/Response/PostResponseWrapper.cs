using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
	internal class PostResponseWrapper
	{
		[JsonProperty("content")]
		public List<PostResponse> content { get; set; }

	}
}
