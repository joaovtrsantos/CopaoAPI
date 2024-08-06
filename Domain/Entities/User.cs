using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        public string Nick { get; set; } = string.Empty;
        public string? Elo { get; set; }
        public string? Pix { get; set; }
    }
}
