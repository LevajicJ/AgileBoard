using AgileBoard.Application.DTOs;
using AgileBoard.Domain.Models;
using System.Net.Http.Json;

namespace AgileBoard.UI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(UserLoginDTO userLoginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/Login", userLoginDto);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
            else
                return null;
        }

        public async Task<bool> Register(UserRegisterDTO userRegisterDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/Register", userRegisterDto);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<int> GetUserByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"api/User/GetUserByEmail/{email}");

            if (response.IsSuccessStatusCode)
            {
                var userId = response.Content.ReadFromJsonAsync<User>();
                return userId.Result.Id;
            }

            return 0;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<User>>("api/User/GetAllUsers");
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var response = await _httpClient.DeleteAsync($"api/User/DeleteUser/{userId}");

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
