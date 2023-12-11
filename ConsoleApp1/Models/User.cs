// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class User
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public User()
        {
            this.Ammunitions = new HashSet<Ammunition>();
            this.Requests = new HashSet<Request>();
            this.SoldierAttrbs = new HashSet<SoldierAttrb>();
            this.VolunteerAttrbs = new HashSet<VolunteerAttrb>();
            this.Weapons = new HashSet<Weapon>();
        }

        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Role { get; set; } = null!;

        public virtual ICollection<Ammunition> Ammunitions { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<SoldierAttrb> SoldierAttrbs { get; set; }

        public virtual ICollection<VolunteerAttrb> VolunteerAttrbs { get; set; }

        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
