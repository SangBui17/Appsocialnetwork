using Newtonsoft.Json;
using Social_network.Repository;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Social_network.ServicesImp
{
    class FriendService : FriendRepository
    {
        private readonly HttpClient _httpClient;

        public FriendService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FriendResponse>> GetAllFriends()
        {
            string url = "http://10.0.2.2:2711/friends/getall/me";  // URL API lấy danh sách bạn bè
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
                    List<FriendResponse> friends = JsonConvert.DeserializeObject<List<FriendResponse>>(jsonResponse);
                    return friends;
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
        public async Task<List<FriendResponse>> GetAllFriendId(long userId)
        {
            string url = $"http://10.0.2.2:2711/friends/getall/{userId}";  // URL API lấy danh sách bạn bè cua user
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
                    List<FriendResponse> friends = JsonConvert.DeserializeObject<List<FriendResponse>>(jsonResponse);
                    return friends;
                }
                // Nếu phản hồi không thành công, ném lỗi
                throw new Exception($"Error fetching friends: {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi lại thông báo lỗi
                Console.WriteLine($"Error in GetFriendsIDAsync: {ex.Message}");
                return null;
            }
        }

        // Thêm bạn mới
        public async Task<bool> AddFriendAsync(string userId)
        {
            string url = $"http://10.0.2.2:2711/friends/add/{userId}";  // URL API thêm bạn

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

                // Gửi yêu cầu POST để thêm bạn mới
                var response = await _httpClient.PostAsync(url, null);

                // Kiểm tra phản hồi
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và ghi lại thông báo lỗi
                Console.WriteLine($"Error in AddFriendAsync: {ex.Message}");
                return false;
            }
        }

        // Xóa bạn
        public async Task<bool> RemoveFriendAsync(string userId)
        {
            string url = $"http://10.0.2.2:2711/friends/remove/{userId}";  // URL API xóa bạn

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

                // Gửi yêu cầu DELETE để xóa bạn
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