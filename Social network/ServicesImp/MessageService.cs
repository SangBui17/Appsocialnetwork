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
    internal class MessageService : MessageRepository
    {
        public string creatMessage(MessageRequest messageRequest, string userTarget)
        {
            throw new NotImplementedException();
        }

        public string deleteMessage(long messageID)
        {
            var client = new HttpClient();
            string url = $"http://10.0.2.2:2711/message/chat/" + messageID;
            try
            {

            }
            catch 
            {

            }
            return null;
        }

        public async Task<List<MessageResponse>> getAllMessageByMeAndUserId(PageInfo pageInfo, long userTarget)
        {
            var client = new HttpClient();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string url = $"http://10.0.2.2:2711/message/getMessage/{userTarget}";

            try
            {
                // Serialize PageInfo using System.Text.Json
                string json = System.Text.Json.JsonSerializer.Serialize(pageInfo, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PostAsync(url, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    // Deserialize using Newtonsoft.Json
                    List<MessageResponse> messageResponses = JsonConvert.DeserializeObject<List<MessageResponse>>(responseContent);
                    Debug.WriteLine("\tLấy thành công.");
                    return messageResponses; // Trả về danh sách messageResponses
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tError: {ex.Message}");
            }

            return null; // Hoặc có thể trả về một danh sách rỗng nếu cần
        }

        public async Task<List<MessageResponse>> getAlluserMessageByme(PageInfo pageInfo)
        {
            var client = new HttpClient();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string url = $"http://10.0.2.2:2711/message/allUser/message/me";

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
                    MessageResposeWrapper resposeWrapper = JsonConvert.DeserializeObject<MessageResposeWrapper>(responseContent);
                    List<MessageResponse> messageResponses = resposeWrapper.content;
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
