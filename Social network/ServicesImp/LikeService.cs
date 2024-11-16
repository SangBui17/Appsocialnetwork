using Newtonsoft.Json;
using Social_network.Models;
using Social_network.Repository;
using Social_network.request;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Social_network.ServicesImp
{
	class LikeService : LikeRepository
	{
		public async Task<string> like(long postId)
		{
			var client = new HttpClient();
			string url = $"http://10.0.2.2:2711/like/{postId}";
			try
			{				
				var token = await SecureStorage.Default.GetAsync("access_token");
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
				{
				};
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
				CancellationToken cancellationToken = new CancellationToken();

				HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
				if (responseMessage.IsSuccessStatusCode)
				{
					return "done like";
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\tError: {ex.Message} \n {ex.StackTrace}");
			}
			return null;
		}
	}
}
