﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            InventoryWeapons = new HashSet<InventoryWeapon>();
            Requests = new HashSet<Request>();
            Routes = new HashSet<Route>();
        }

        public int WeaponId { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<InventoryWeapon> InventoryWeapons { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
