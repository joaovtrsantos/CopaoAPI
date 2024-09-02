using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class SignupUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Nick { get; set; } = string.Empty;

        public string? Elo { get; set; }

        public string? Pix { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}

