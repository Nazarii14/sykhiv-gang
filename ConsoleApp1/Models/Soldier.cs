using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Soldier
    {
        public int Id { get; set; }
        public string CallSign { get; set; } = null!;
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
