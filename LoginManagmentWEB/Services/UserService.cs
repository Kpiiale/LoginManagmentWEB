using LoginManagmentWEB.Models;
using LoginManagmentWEB.Services.Auth;

namespace LoginManagmentWEB.Services
{
    public class UserService
    {
        private readonly HttpClient _http;
        

        public UserService(HttpClient http)
        {
            _http = http;
            
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<PagedUsersResponse>("api/users?page=1&pageSize=50");
                Console.WriteLine($"[UserService] Recibidos {response?.Items.Count ?? 0} usuarios");
                return response?.Items ?? new List<UserDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllAsync error: {ex.Message}");
                throw;
            }
        }
        public async Task<UserDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<UserDto>($"api/users/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetByIdAsync error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> CreateAsync(CreateUserRequest create)
        {
            try
            {
                
                var response = await _http.PostAsJsonAsync("api/users", create);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CreateAsync error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserRequest update)
        {
            try
            {
                
                var response = await _http.PutAsJsonAsync($"api/users/{id}", update);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateAsync error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/users/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteAsync error: {ex.Message}");
                return false;
            }
        }
    }
}

