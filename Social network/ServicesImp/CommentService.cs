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
    internal class CommentService : CommentRepository
    {
        public async Task<List<CommentResponse>> getAllcmtByPostId(PageInfo pageInfo, long id)
        {
            var client = new HttpClient();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string url = $"http://10.0.2.2:2711/comment/all/{id}";

            try
            {
                // Serialize PageInfo using System.Text.Json
                string json = System.Text.Json.JsonSerializer.Serialize(pageInfo, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var token = await SecureStorage.Default.GetAsync("access_token");
                if (token == null)
                {
                    Debug.WriteLine("Access token is missing.");
                    return null;
                }
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
                    CommentResponseWrapper resposeWrapper = JsonConvert.DeserializeObject<CommentResponseWrapper>(responseContent);
                    List<CommentResponse> messageResponses = resposeWrapper.content;
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

        public async Task<string> addComment(CommentRequest commentRequest, long postId)
        {
            var client = new HttpClient();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string url = $"http://10.0.2.2:2711/comment/{postId}";
            try
            {
                // Serialize commentRequest using System.Text.Json
                string json = System.Text.Json.JsonSerializer.Serialize(commentRequest, serializerOptions);
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

        public string deleteComment(long cmtId)
        {
            throw new NotImplementedException();
        }
    }
}