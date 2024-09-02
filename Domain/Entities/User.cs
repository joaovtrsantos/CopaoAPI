using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    [Table("User")]
    public class User : Base
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nick { get; set; } = string.Empty;
        public string? Rank { get; set; }
        public string? Pix { get; set; }
    }
}
