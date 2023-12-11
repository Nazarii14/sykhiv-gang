// <copyright file="Request.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public int? SenterSoldier { get; set; }
        public int? ReceiverAdmin { get; set; }
        public int? WeaponId { get; set; }
        public int? AmmunitionId { get; set; }
        public int QuantityRequested { get; set; }
        public string? Message { get; set; }
        public string RequestStatus { get; set; } = null!;

        public virtual Ammunition? Ammunition { get; set; }
        public virtual User? ReceiverAdminNavigation { get; set; }
        public virtual SoldierAttrb? SenterSoldierNavigation { get; set; }
        public virtual Weapon? Weapon { get; set; }
    }
}
