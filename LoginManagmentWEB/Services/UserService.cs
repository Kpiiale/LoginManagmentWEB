using LoginManagmentWEB.Models;
using Microsoft.JSInterop;

namespace LoginManagmentWEB.Services
{
    public class UserService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;

        public UserService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            try
            {
                var users = await _js.InvokeAsync<List<UserDto>>("authFetch.getJson", "api/users");
                return users ?? new List<UserDto>();
            }
            catch (JSException ex)
            {
                Console.WriteLine($"GetAllAsync JS fetch error: {ex.Message}");
                throw;
            }
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _js.InvokeAsync<UserDto?>("authFetch.getJson", $"api/users/{id}");
            }
            catch (JSException ex)
            {
                Console.WriteLine($"GetByIdAsync JS fetch error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> CreateAsync(CreateUserRequest create)
        {
            try
            {
                await _js.InvokeVoidAsync("authFetch.postJson", "api/users", create);
                return true;
            }
            catch (JSException ex)
            {
                Console.WriteLine($"CreateAsync JS fetch error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserRequest update)
        {
            try
            {
                await _js.InvokeVoidAsync("authFetch.putJson", $"api/users/{id}", update);
                return true;
            }
            catch (JSException ex)
            {
                Console.WriteLine($"UpdateAsync JS fetch error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _js.InvokeVoidAsync("authFetch.deleteJson", $"api/users/{id}");
                return true;
            }
            catch (JSException ex)
            {
                Console.WriteLine($"DeleteAsync JS fetch error: {ex.Message}");
                return false;
            }
        }
    }
}
