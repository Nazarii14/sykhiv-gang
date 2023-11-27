using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Ammunition
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Size { get; set; } = null!;
        public string Gender { get; set; } = null!;

        // Owner of ammunition
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
