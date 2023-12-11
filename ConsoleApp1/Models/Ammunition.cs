// <copyright file="Ammunition.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;

#pragma warning disable SA1601 // Partial elements should be documented
    public partial class Ammunition
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public Ammunition()
        {
            this.InventoryAmmunitions = new HashSet<InventoryAmmunition>();
            this.Requests = new HashSet<Request>();
            this.Routes = new HashSet<Route>();
        }

        public int AmmunitionId { get; set; }

        public string Type { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Size { get; set; } = null!;

        public string UsersGender { get; set; } = null!;

        public int? UserId { get; set; }

        public int? NeededAmount { get; set; }

        public int? AvailableAmount { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<InventoryAmmunition> InventoryAmmunitions { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
