// <copyright file="InventoryWeapon.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class InventoryWeapon
    {
        public int InventoryWeaponId { get; set; }
        public int? WeaponId { get; set; }
        public int GeneralQuantity { get; set; }
        public int StorageQuantity { get; set; }

        public virtual Weapon? Weapon { get; set; }
    }
}
