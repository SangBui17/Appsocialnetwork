
using Microsoft.Maui.Networking;
using Microsoft.Maui.Storage;
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



        //private readonly Cookie _token;

        /*public LoginService(Cookie token)
        {
            _token = token;
        }*/
        public async Task<LoginInfo> Login(string username, string password)
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
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Response Content: {responseContent}"); // Kiểm tra nội dung phản hồi

                        // Deserialize JSON bằng cách sử dụng Newtonsoft.Json
                        var userInfo = JsonConvert.DeserializeObject<LoginInfo>(responseContent);
                        LoginInfo loginInfo = JsonConvert.DeserializeObject<LoginInfo>(responseContent);
                        // Print each field of the loginInfo object
                        Console.WriteLine("Token: " + loginInfo.token);
                        Console.WriteLine("Username: " + loginInfo.username);
                        //Console.WriteLine("Roles: " + (loginInfo.role));
                        /*try
                        {
                            _appconfig.cookieStore().LCookie = loginInfo.token;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error in SetCookie: {ex.Message}");
                        };*/

                        try
                        {
                            await SecureStorage.Default.SetAsync("access_token", loginInfo.token);
                            await SecureStorage.Default.SetAsync("id_token", loginInfo.username);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error", ex.Message, "Ok");
                        }

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
                await Application.Current.MainPage.DisplayAlert("No Internet", "Kết nối của bạn không ổn định,.", "OK");
            }

            // Return null if login failed
            return null;
        }

        public string Logout()
        {
            var client = new HttpClient();
            string url = "http://10.0.2.2:2711/auth/signout";
            var requestLogout = client.GetAsync(url);
                string response = requestLogout.ToString();
                if(response.Equals("Logout OK"))
                {
                    SecureStorage.Default.RemoveAll();
                    return "done logout";
                }
            return "logout fail";
        }
    }
}
