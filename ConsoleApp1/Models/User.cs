// <copyright file="User.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            Ammunitions = new HashSet<Ammunition>();
            Requests = new HashSet<Request>();
            SoldierAttrbs = new HashSet<SoldierAttrb>();
            VolunteerAttrbs = new HashSet<VolunteerAttrb>();
            Weapons = new HashSet<Weapon>();
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
