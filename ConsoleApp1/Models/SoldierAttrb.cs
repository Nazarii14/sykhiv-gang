// <copyright file="SoldierAttrb.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SoldierAttrb
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
