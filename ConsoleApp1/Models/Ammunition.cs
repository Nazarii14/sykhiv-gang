using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Ammunition
    {
        public int AmmunitionId { get; set; }

        public string Type { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Size { get; set; } = null!;

        public string UsersGender { get; set; } = null!;

        public int? UserId { get; set; }

        public int? NeededAmount { get; set; }

        public int? AvailableAmount { get; set; }

        public decimal Moneyneeded { get; set; }

        public decimal Percentage { get; set; }

        public virtual ICollection<InventoryAmmunition> InventoryAmmunitions { get; } = new List<InventoryAmmunition>();

        public virtual ICollection<Request> Requests { get; } = new List<Request>();

        public virtual ICollection<Route> Routes { get; } = new List<Route>();

        public virtual User? User { get; set; }
    }
}
