using System;
using System.Collections.Generic;

namespace DAL;

public partial class VolunteerAttrb
{
    public int VolunteerAttrbId { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Route> Routes { get; } = new List<Route>();

    public virtual User? User { get; set; }
}
