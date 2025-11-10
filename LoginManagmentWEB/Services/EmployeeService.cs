using LoginManagmentWEB.Models;
namespace LoginManagmentWEB.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _http;

        public EmployeeService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync(int? companyId = null)
        {
            var url = companyId.HasValue ? $"api/Employees/ByCompany/{companyId}" : "api/Employees";
            return await _http.GetFromJsonAsync<List<EmployeeDto>>(url) ?? new();
        }

        public async Task<EmployeeDto?> GetEmployeeAsync(int id)
        {
            return await _http.GetFromJsonAsync<EmployeeDto>($"api/Employees/{id}");
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeDto employee)
        {
            var response = await _http.PostAsJsonAsync("api/Employees", employee);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeDto employee)
        {
            var response = await _http.PutAsJsonAsync($"api/Employees/{employee.Id}", employee);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Employees/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}