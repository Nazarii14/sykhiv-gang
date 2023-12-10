using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class VolunteerAttrb
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
