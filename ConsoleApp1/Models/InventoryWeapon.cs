// <copyright file="InventoryWeapon.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class InventoryWeapon
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public int InventoryWeaponId { get; set; }

        public int? WeaponId { get; set; }

        public int GeneralQuantity { get; set; }

        public int StorageQuantity { get; set; }

        public virtual Weapon? Weapon { get; set; }
    }
}
