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
    internal class NotificationFollowResponse : BaseEntity
	{
		[JsonProperty("post_id")]

		public long postId { get; set; }

		[JsonProperty("share_id")]

		public long? shareId { get; set; }

		public string? avatar { get; set; }

	}
}
