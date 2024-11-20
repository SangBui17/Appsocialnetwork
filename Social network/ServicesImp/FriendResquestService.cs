using Newtonsoft.Json;
using Social_network.Repository;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Social_network.Models;

namespace Social_network.ServicesImp
{
    class FriendResquestService : FriendResquestRepository
    {
        private readonly HttpClient _httpClient;

        public FriendResquestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<FriendRequestResponse>> getAllFriendRequest()
        {
            string url = "http://10.0.2.2:2711/friendrequest/getall";  // URL API lấy danh sách bạn bè
            try
            {
                // Lấy token từ SecureStorage
                var token = await SecureStorage.Default.GetAsync("access_token");
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("Token is missing");
                }
                // Thiết lập header Authorization cho yêu cầu HTTP
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                // Gửi yêu cầu GET tới API
                var response = await _httpClient.GetAsync(url);
                // Kiểm tra phản hồi của API
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung và giải mã JSON thành danh sách bạn bè
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<FriendRequestResponse> friendrequest = JsonConvert.DeserializeObject<List<FriendRequestResponse>>(jsonResponse);
                    return friendrequest;
                }
                // Nếu phản hồi không thành công, ném lỗi
                throw new Exception($"Error fetching friends: {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi lại thông báo lỗi
                Console.WriteLine($"Error in GetFriendsAsync: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> AddFriendResquest(long id)
        {
            string url = $"http://10.0.2.2:2711/friendrequest/add/{id}";  // URL API thêm bạn

            try
            {
                // Lấy token từ SecureStorage
                var token = await SecureStorage.Default.GetAsync("access_token");
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("Token is missing");
                }

                // Thiết lập headers
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Gửi yêu cầu GET
                var response = await _httpClient.SendAsync(requestMessage);

                // Trả về nội dung phản hồi
                return true;
            }

            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi lại thông báo lỗi
                Console.WriteLine($"Error in AddFriendAsync: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> RemoveFriendRequest(long id)
        {
            string url = $"http://10.0.2.2:2711/friendrequest/remove/{id}";  // URL API xóa loi moi ket bạn

            try
            {
                // Lấy token từ SecureStorage
                var token = await SecureStorage.Default.GetAsync("access_token");
                if (string.IsNullOrEmpty(token))
                {
                    throw new Exception("Token is missing");
                }

                // Thiết lập header Authorization cho yêu cầu HTTP
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Gửi yêu cầu DELETE để xóa loi moi ket bạn
                var response = await _httpClient.DeleteAsync(url);

                // Kiểm tra phản hồi
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi lại thông báo lỗi
                Console.WriteLine($"Error in RemoveFriendAsync: {ex.Message}");
                return false;
            }
        }
        


    }
}
