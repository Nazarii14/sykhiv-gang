// <copyright file="Weapon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using System.Collections.Generic;

#pragma warning disable SA1601 // Partial elements should be documented
    public partial class Weapon
#pragma warning restore SA1601 // Partial elements should be documented
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
