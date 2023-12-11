using System;
using System.Collections.Generic;

namespace DAL;

public partial class SoldierAttrb
{
    public int SoldierAttrbId { get; set; }

    public string Callsign { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual User? User { get; set; }
}
