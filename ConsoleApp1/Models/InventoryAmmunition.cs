// <copyright file="InventoryAmmunition.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class InventoryAmmunition
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public int InventoryAmmunitionId { get; set; }

        public int? AmmunitionId { get; set; }

        public int GeneralAmmunition { get; set; }

        public int StorageAmmunition { get; set; }

        public int? BrigadeId { get; set; }

        public virtual Ammunition? Ammunition { get; set; }
    }
}
