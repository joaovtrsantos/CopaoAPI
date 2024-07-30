using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("UserTeam")]
    public class UserTeam : Base
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }

        public required virtual User Usuario { get; set; }
        public required virtual Team Time { get; set; }
    }
}
