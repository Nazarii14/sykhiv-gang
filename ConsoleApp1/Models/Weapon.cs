using System;
using System.Collections.Generic;

namespace DAL;

public partial class Weapon
{
    public int WeaponId { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Weight { get; set; }

    public int? UserId { get; set; }

    public int? NeededAmount { get; set; }

    public int? AvailableAmount { get; set; }

    public decimal Percentage { get; set; }

    public decimal Moneyneeded { get; set; }

    public virtual ICollection<InventoryWeapon> InventoryWeapons { get; } = new List<InventoryWeapon>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual ICollection<Route> Routes { get; } = new List<Route>();

    public virtual User? User { get; set; }
}
