// <copyright file="SoldierAttrb.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class SoldierAttrb
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public SoldierAttrb()
        {
            this.Requests = new HashSet<Request>();
        }

        public int SoldierAttrbId { get; set; }

        public string Callsign { get; set; } = null!;

        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
