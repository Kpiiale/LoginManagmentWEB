namespace LoginManagmentWEB.Models
{
    public class RegistrationResult
    {
        public bool Success { get; set; }
        public AuthResponseDto? Data { get; set; }
        public string? Error { get; set; }
        public int StatusCode { get; set; }
    }
}