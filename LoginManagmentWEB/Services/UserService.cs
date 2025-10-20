using LoginManagmentWEB.Models;

namespace LoginManagmentWEB.Services
{
    public class UserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http) => _http = http;

        public async Task<List<UserDto>> GetAllAsync() =>
            await _http.GetFromJsonAsync<List<UserDto>>("api/users") ?? new List<UserDto>();

        public async Task<UserDto?> GetByIdAsync(int id) =>
            await _http.GetFromJsonAsync<UserDto>($"api/users/{id}");

        public async Task<bool> CreateAsync(CreateUserRequest create) =>
            (await _http.PostAsJsonAsync("api/users", create)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(int id, UpdateUserRequest update) =>
            (await _http.PutAsJsonAsync($"api/users/{id}", update)).IsSuccessStatusCode;

        public async Task<bool> DeleteAsync(int id) =>
            (await _http.DeleteAsync($"api/users/{id}")).IsSuccessStatusCode;
    }
}
