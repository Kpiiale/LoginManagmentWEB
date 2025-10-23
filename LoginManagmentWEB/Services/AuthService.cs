using LoginManagmentWEB.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace LoginManagmentWEB.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        public AuthService(HttpClient http) => _http = http;

        public async Task<RegistrationResult> RegisterAsync(RegisterDto dto)
        {
            try
            {
                dto.CreatedBy = "autocreado";
                var response = await _http.PostAsJsonAsync("api/auth/register", dto);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                    return new RegistrationResult
                    {
                        Success = true,
                        Data = data,
                        StatusCode = (int)response.StatusCode
                    };
                }

                var errorBody = await response.Content.ReadAsStringAsync();
                var errorText = string.IsNullOrWhiteSpace(errorBody) ? response.ReasonPhrase : errorBody;

                Console.WriteLine($"Register failed: {(int)response.StatusCode} {response.ReasonPhrase} - {errorBody}");

                return new RegistrationResult
                {
                    Success = false,
                    Error = errorText,
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Register HTTP request error: {ex.Message}");
                return new RegistrationResult
                {
                    Success = false,
                    Error = ex.Message,
                    StatusCode = 0
                };
            }
        }

        public async Task<RegistrationResult> LoginAsync(LoginDto dto)
        {
            try
            {
              
                try
                {
                    var payload = JsonSerializer.Serialize(dto);
                    Console.WriteLine($"Login request payload: {payload}");
                }
                catch { /* ignore serialization errors for logging */ }

                var response = await _http.PostAsJsonAsync("api/auth/login", dto);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<AuthResponseDto>();
                    return new RegistrationResult
                    {
                        Success = true,
                        Data = data,
                        StatusCode = (int)response.StatusCode
                    };
                }

                var errorBody = await response.Content.ReadAsStringAsync();
                var errorText = string.IsNullOrWhiteSpace(errorBody) ? response.ReasonPhrase : errorBody;

                Console.WriteLine($"Login failed: {(int)response.StatusCode} {response.ReasonPhrase} - {errorBody}");

                return new RegistrationResult
                {
                    Success = false,
                    Error = errorText,
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Login HTTP request error: {ex.Message}");
                return new RegistrationResult
                {
                    Success = false,
                    Error = ex.Message,
                    StatusCode = 0
                };
            }
        }
    }
}
