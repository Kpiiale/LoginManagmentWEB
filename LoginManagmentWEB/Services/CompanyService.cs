using LoginManagmentWEB.Models;

namespace LoginManagmentWEB.Services
{
    public class CompanyService
    {
        private readonly HttpClient _http;

        public CompanyService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CompanyDto>> GetCompaniesAsync()
        {
            return await _http.GetFromJsonAsync<List<CompanyDto>>("api/Companies") ?? new();
        }

        public async Task<CompanyDto?> GetCompanyAsync(int id)
        {
            return await _http.GetFromJsonAsync<CompanyDto>($"api/Companies/{id}");
        }

        public async Task<bool> CreateCompanyAsync(CompanyDto company)
        {
            var response = await _http.PostAsJsonAsync("api/Companies", company);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCompanyAsync(CompanyDto company)
        {
            var response = await _http.PutAsJsonAsync($"api/Companies/{company.Id}", company);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Companies/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

