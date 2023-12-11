// <copyright file="Route.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;

#pragma warning disable SA1601 // Partial elements should be documented
    public partial class Route
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public int RouteId { get; set; }

        public int? VolunteerId { get; set; }

        public int? WeaponId { get; set; }

        public int? AmmunitionId { get; set; }

        public string StartingPoint { get; set; } = null!;

        public string DestinationPoint { get; set; } = null!;

        public int QuantityDelivered { get; set; }

        public DateOnly DeliveryDate { get; set; }

        public virtual Ammunition? Ammunition { get; set; }

        public virtual VolunteerAttrb? Volunteer { get; set; }

        public virtual Weapon? Weapon { get; set; }
    }
}
