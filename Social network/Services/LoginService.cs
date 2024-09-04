
using Newtonsoft.Json;
using Social_network.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Services
{
    class LoginService : LoginRepository
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var client = new HttpClient();
                string url = "http://10.0.2.2:2711/auth/login";

                // Create the request body as a JSON object
                var loginRequest = new
                {
                    username = username,
                    password = password
                };

                // Serialize the request body to JSON
                var jsonContent = JsonConvert.SerializeObject(loginRequest);
                Console.WriteLine($"Serialized JSON: {jsonContent}");
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                Console.WriteLine($"rako: {content}");

                try
                {
                    // Send the POST request
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine($"Response Content: {responseContent}"); // Kiểm tra nội dung phản hồi
                        var userInfo = JsonConvert.DeserializeObject<UserInfo>(responseContent);
                        return userInfo;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., network issues)
                    Debug.WriteLine($"Login failed: {ex.Message}");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("No Internet", "Please check your internet connection.", "OK");
            }

            // Return null if login failed
            return null;
        }
    }
}
