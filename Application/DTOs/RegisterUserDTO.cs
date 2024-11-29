using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;

        [JsonIgnore, Required]
        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nick { get; set; } = string.Empty;
        public string? Rank { get; set; }
        public string? Pix { get; set; }
    }
}
