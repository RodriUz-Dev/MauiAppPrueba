using MauiAppPrueba.Entities;
using MauiAppPrueba.Entities.DTOs;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MauiAppPrueba.Services
{
    public class UserService : IUserRepository
    {
        private readonly string baseUri;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            baseUri = _configuration.GetSection("ApiBaseUrl")?.Value ?? string.Empty;
        }

        public async Task<User?> Login(string email, string password)
        {
            var loginDTO = new LoginDTO() { Email = email, Password = password };
            string json = JsonSerializer.Serialize(loginDTO);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();            
            var response = await client.PostAsync($"{baseUri}/users/login", content);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                if (user == null)
                {
                    user = new User() { Email = string.Empty, Password = string.Empty, Id = 0 };
                    return user;
                }
                return user;
            }
            else
            {
                var user = new User() { Email = string.Empty, Password = string.Empty, Id = 0 };
                return user;
            }
        }

        public async Task<User> Create(User user)
        {
            string json = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var response = await client.PostAsync($"{baseUri}/users", content);

            if (response.IsSuccessStatusCode) 
            {
                var newUser = await response.Content.ReadFromJsonAsync<User>();
                if (newUser == null)
                {
                    return new User() { Email = string.Empty, Password = string.Empty, Id = 0 };
                }
                return newUser;
            }
            else
            {
                return new User() { Email = string.Empty, Password = string.Empty, Id = 0 };
            }                   
        }

        public async Task<User> Update(User user)
        {
            string json = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var response = await client.PutAsync($"{baseUri}/users/{user.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                var editUser = await response.Content.ReadFromJsonAsync<User>();
                if (editUser == null)
                {
                    return new User() { Email = string.Empty, Password = string.Empty, Id = 0 };
                }
                return editUser;
            }
            else
            {
                return new User() { Email = string.Empty, Password = string.Empty, Id = 0 };
            }
        }

        public async Task<bool> Delete(int id)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"{baseUri}/users/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }            
            return false;
        }
    }
}
