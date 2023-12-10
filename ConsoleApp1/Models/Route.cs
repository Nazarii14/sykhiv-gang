using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Route
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
