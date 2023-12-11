// <copyright file="Brigade.cs" company="SykhivGang">
// Copyright (c) SykhivGang. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Brigade
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? CommanderName { get; set; }
        public DateOnly? EstablishmentDate { get; set; }
        public string? Location { get; set; }
    }
}
