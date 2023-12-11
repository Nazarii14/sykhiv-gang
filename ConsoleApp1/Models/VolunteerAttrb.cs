// <copyright file="VolunteerAttrb.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
#pragma warning disable SA1601 // Partial elements should be documented
    public partial class VolunteerAttrb
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public VolunteerAttrb()
        {
            this.Routes = new HashSet<Route>();
        }

        public int VolunteerAttrbId { get; set; }

        public string? Status { get; set; }

        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
