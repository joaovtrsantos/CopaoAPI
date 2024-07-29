using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TeamTournament")]
    public class TeamTournament : Base
    {
        public int TeamId { get; set; }
        public int TournamentId { get; set; }

        public required virtual Team Time { get; set; }
        public required virtual Tournament Torneio { get; set; }
    }
}
