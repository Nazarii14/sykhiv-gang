// <copyright file="Weapon.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            this.InventoryWeapons = new HashSet<InventoryWeapon>();
            this.Requests = new HashSet<Request>();
            this.Routes = new HashSet<Route>();
        }

        public int WeaponId { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int? UserId { get; set; }
        public int? NeededAmount { get; set; }
        public int? AvailableAmount { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<InventoryWeapon> InventoryWeapons { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
