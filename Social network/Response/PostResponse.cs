using Newtonsoft.Json;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
	internal class PostResponse : BaseEntity
	{
		[JsonProperty("author")]
		public UserAuthorResponse authorResponse { get; set; }
		public string content { get; set; }
		public int privacy { get; set; }
		public int id { get; set; }

		[JsonProperty("images")]

		public List<ImageResponse> images { get; set; }

		[JsonProperty("like_count")]

		public long likeCount { get; set; }


		[JsonProperty("cmt_count")]

		public long commentCount { get; set; }

		[JsonProperty("share_count")]

		public long shareCount { get; set; }

		public bool liked { get; set; }
	}
}
