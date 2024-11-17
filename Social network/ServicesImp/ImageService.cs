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
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Social_network.ServicesImp
{
	internal class ImageService : ImageRepository
	{
		public async Task<List<ImageResponse>> getAll()
		{
			var client = new HttpClient();
			string url = $"http://10.0.2.2:2711/image";

			try
			{
				var token = await SecureStorage.Default.GetAsync("access_token");
				if (token == null)
				{
					Debug.WriteLine("Access token is missing.");
					return null;
				}
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url)
				{
					//Content = content
				};
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
				CancellationToken cancellationToken = new CancellationToken();

				HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
				if (responseMessage.IsSuccessStatusCode)
				{
					string responseContent = await responseMessage.Content.ReadAsStringAsync();
					Debug.WriteLine($"Response: {responseContent}");
					List<ImageResponse> messageResponses = JsonConvert.DeserializeObject<List<ImageResponse>>(responseContent);
					Debug.WriteLine("\tLấy thành công.");
					return messageResponses; // Trả về danh sách messageResponses
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"\tError: {ex.Message} \n {ex.StackTrace}");
			}

			return null; // Hoặc có thể trả về một danh sách rỗng nếu cần
		}
	}
}
