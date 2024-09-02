using System.ComponentModel;

namespace Application.Models.Requests
{
    public class LoginRequest
    {
        [DefaultValue("System")]
        public required string Username { get; set; }

        [DefaultValue("System")]
        public required string Password { get; set; }
    }
}
