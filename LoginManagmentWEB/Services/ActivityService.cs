using LoginManagmentWEB.Models;

namespace LoginManagmentWEB.Services
{
    public class ActivityService
    {
        private readonly HttpClient _http;

        public ActivityService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ActivityDto>> GetActivitiesAsync(int? companyId = null)
        {
            var url = companyId.HasValue ? $"api/Activities/ByCompany/{companyId}" : "api/Activities";
            return await _http.GetFromJsonAsync<List<ActivityDto>>(url) ?? new();
        }

        public async Task<ActivityDto?> GetActivityAsync(int id)
        {
            return await _http.GetFromJsonAsync<ActivityDto>($"api/Activities/{id}");
        }

        public async Task<bool> CreateActivityAsync(ActivityDto activity)
        {
            var response = await _http.PostAsJsonAsync("api/Activities", activity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateActivityAsync(ActivityDto activity)
        {
            var response = await _http.PutAsJsonAsync($"api/Activities/{activity.Id}", activity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteActivityAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Activities/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}