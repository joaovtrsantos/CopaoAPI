using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Team")]
    public class Team : Base
    {
        public string Name { get; set; } = string.Empty;
        public int CaptainId { get; set; }
        public string Logo { get; set; } = string.Empty;

        public required virtual User Captain { get; set; }
    }
}
