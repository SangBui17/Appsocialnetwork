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
	class PostService : PostRepository
	{
		public async Task<List<PostResponse>> getAllPost(PageInfo pageinfo)
		{
			var client = new HttpClient();
			var serializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
			string url = $"http://10.0.2.2:2711/post/get/All";
			try
			{
				// Serialize PageInfo using System.Text.Json
				string json = System.Text.Json.JsonSerializer.Serialize(pageinfo, serializerOptions);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
				var token = await SecureStorage.Default.GetAsync("access_token");
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
				{
					Content = content
				};
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
				CancellationToken cancellationToken = new CancellationToken();

				HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
				if (responseMessage.IsSuccessStatusCode)
				{
					string responseContent = await responseMessage.Content.ReadAsStringAsync();
					Debug.WriteLine($"Response: {responseContent}");
					// Deserialize using Newtonsoft.Json
					//MessageResposeWrapper messageResposeWrapper = JsonConvert.DeserializeObject(responseContent);
					PostResponseWrapper resposeWrapper = JsonConvert.DeserializeObject<PostResponseWrapper>(responseContent);
					List<PostResponse> messageResponses = resposeWrapper.content;
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
		public async Task<string> createPost(PostRequest postRequest)
		{
			var client = new HttpClient();
			var serializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
			string url = $"http://10.0.2.2:2711/post";
			try
			{
				// Serialize commentRequest using System.Text.Json
				string json = System.Text.Json.JsonSerializer.Serialize(postRequest, serializerOptions);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
				var token = await SecureStorage.Default.GetAsync("access_token");
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
				{
					Content = content
				};
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
				CancellationToken cancellationToken = new CancellationToken();

				HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
				if (responseMessage.IsSuccessStatusCode)
				{
					string responseContent = await responseMessage.Content.ReadAsStringAsync();
					Debug.WriteLine($"Response: {responseContent}");
					Debug.WriteLine("\tLấy thành công.");
					return responseContent; // Trả về danh sách messageResponses
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
