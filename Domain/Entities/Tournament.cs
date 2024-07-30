using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Tournament")]
    public class Tournament : Base
    {
        public string Name { get; set; } = string.Empty;
        public int TeamsQuantity { get; set; }
        public DateTime StartDate { get; set; }
        public int ChampionId { get; set; }

        public virtual Team? Champion { get; }

    }
}
