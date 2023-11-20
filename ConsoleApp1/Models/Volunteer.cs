using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
