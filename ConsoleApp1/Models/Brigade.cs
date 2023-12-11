// <copyright file="Brigade.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;

#pragma warning disable SA1601 // Partial elements should be documented
    public partial class Brigade
#pragma warning restore SA1601 // Partial elements should be documented
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? CommanderName { get; set; }

        public DateOnly? EstablishmentDate { get; set; }

        public string? Location { get; set; }
    }
}
