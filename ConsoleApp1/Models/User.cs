using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname{ get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Ammunition> Ammunitions { get; set; }
    }
}
