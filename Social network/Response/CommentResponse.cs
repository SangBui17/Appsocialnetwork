using Newtonsoft.Json;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Response
{
    internal class CommentResponse : BaseEntity
	{
		public string content { get; set; }

		[JsonProperty("author")]

		public UserAuthorResponse userAuthorResponse { get; set; }

		[JsonProperty("image")]

		public ImageResponse imageResponse { get; set; }
	}
}
