// <copyright file="Request.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class Request
#pragma warning restore SA1601 // Partial elements should be documented
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
