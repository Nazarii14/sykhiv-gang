using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Ammunition> Ammunitions { get; } = new List<Ammunition>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public virtual ICollection<SoldierAttrb> SoldierAttrbs { get; } = new List<SoldierAttrb>();

    public virtual ICollection<VolunteerAttrb> VolunteerAttrbs { get; } = new List<VolunteerAttrb>();

    public virtual ICollection<Weapon> Weapons { get; } = new List<Weapon>();
}
