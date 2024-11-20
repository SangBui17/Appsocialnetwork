using Newtonsoft.Json;
using Social_network.Repository;
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
    class UserInfoService : UserInfoRepository
    {
        public async Task<UserInfoResponse> GetUserInfo()
        {
            var client = new HttpClient();
            string url = $"http://10.0.2.2:2711/user/me";

            try
            {
                var token = await SecureStorage.Default.GetAsync("access_token");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                CancellationToken cancellationToken = new CancellationToken();

                HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Response: {responseContent}");
                    // Deserialize using Newtonsoft.Json
                    //MessageResposeWrapper messageResposeWrapper = JsonConvert.DeserializeObject(responseContent);
                    UserInfoResponse me = JsonConvert.DeserializeObject<UserInfoResponse>(responseContent);
                    Debug.WriteLine("\tLấy thành công.");
                    return me; // Trả về danh sách messageResponses
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tError: {ex.Message} \n {ex.StackTrace}");
            }

            return null; // Hoặc có thể trả về một danh sách rỗng nếu cần
        }

        public async Task<UserInfoResponse> GetUserById(long userId)
        {
            var client = new HttpClient();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string url = $"http://10.0.2.2:2711/user/{userId}";

            try
            {
                var token = await SecureStorage.Default.GetAsync("access_token");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                CancellationToken cancellationToken = new CancellationToken();

                HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    // Deserialize using Newtonsoft.Json
                    UserInfoResponse messageResponses = JsonConvert.DeserializeObject<UserInfoResponse>(responseContent);
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

        public async Task<UserInfoResponse> FindByUsername(string username)
        {
            var client = new HttpClient();
            string url = $"http://10.0.2.2:2711/user/username/{username}"; // URL API lấy danh sách bạn bè
            try
            {
                // Lấy token từ SecureStorage
                var token = await SecureStorage.Default.GetAsync("access_token");
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("Token is missing");
                }
                // Thiết lập header Authorization cho yêu cầu HTTP
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // Gửi yêu cầu GET tới API
                var response = await client.GetAsync(url);
                // Kiểm tra phản hồi của API
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung và giải mã JSON thành danh sách bạn bè
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"search: {jsonResponse}");
                    UserInfoResponse user = JsonConvert.DeserializeObject<UserInfoResponse>(jsonResponse);
                    Console.WriteLine("search: " + user);
                    return user;
                }
                // Nếu phản hồi không thành công, ném lỗi
                throw new Exception($"Error fetching search user: {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi lại thông báo lỗi
                Console.WriteLine($"Error in findByUsername: {ex.Message}");
                return null;
            }
        }
    }
}
