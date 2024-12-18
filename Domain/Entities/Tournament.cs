using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Tournament")]
    public class Tournament : Base
    {
        public string Name { get; set; } = string.Empty;
        public int MaxParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public int ChampionId { get; set; }
        public virtual Team? Champion { get; }

    }
}
