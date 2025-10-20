using System.ComponentModel.DataAnnotations;

namespace LoginManagmentWEB.Models
{
    public class CreateUserRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;
    }
}