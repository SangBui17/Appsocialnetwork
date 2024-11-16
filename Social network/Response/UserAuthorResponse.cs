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
	class UserAuthorResponse : BaseEntity
	{
		[JsonProperty("username")]
		public string username { get; set; }

		[JsonProperty("last_name")]
		public string lastName { get; set; }

		[JsonProperty("first_name")]
		public string firstName { get; set; }

		public string fullName => $"{lastName} {firstName}";

		[JsonProperty("avatar_image")]
		public ImageResponse avatar { get; set; }
	}
}
