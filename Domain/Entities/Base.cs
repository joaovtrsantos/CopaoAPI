using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Base
    {
        [Key] public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? ChangeDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
