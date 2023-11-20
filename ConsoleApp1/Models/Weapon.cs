using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public double Weight { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
