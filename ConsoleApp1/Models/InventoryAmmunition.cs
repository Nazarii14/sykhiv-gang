using System;
using System.Collections.Generic;

namespace DAL;

public partial class InventoryAmmunition
{
    public int InventoryAmmunitionId { get; set; }

    public int? AmmunitionId { get; set; }

    public int GeneralAmmunition { get; set; }

    public int StorageAmmunition { get; set; }

    public int? BrigadeId { get; set; }

    public virtual Ammunition? Ammunition { get; set; }
}
