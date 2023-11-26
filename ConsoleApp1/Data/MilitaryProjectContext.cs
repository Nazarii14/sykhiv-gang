//-----------------------------------------------------------------------
// <copyright file="MilitaryProjectContext.cs" company="SykhivGang">
//     Copyright (c) SykhivGang. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DAL.Data
{
    using System;
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    /// <summary>
    /// This is a description of what the partial class does.
    /// </summary>
    public partial class MilitaryProjectContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MilitaryProjectContext"/> class.
        /// </summary>
        public MilitaryProjectContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MilitaryProjectContext"/> class.
        /// </summary>
        /// <param name="options">Параметри, які будуть використовуватися <see cref="DbContext"/>.</param>
        public MilitaryProjectContext(DbContextOptions<MilitaryProjectContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Gets or sets cookery Users.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets Weapons.
        /// </summary>
        public virtual DbSet<Weapon> Weapons { get; set; }

        /// <summary>
        /// Gets or sets Volunteers.
        /// </summary>
        public virtual DbSet<Volunteer> Volunteers { get; set; }

        /// <summary>
        /// Gets or sets Ammunitions.
        /// </summary>
        public virtual DbSet<Ammunition> Ammunitions { get; set; }

        /// <summary>   
        /// Gets or sets Soldiers.
        /// </summary>
        public virtual DbSet<Soldier> Soldiers { get; set; }

        /// <summary>
        /// Налаштовує контекст для використання PostgreSQL бази даних.
        /// </summary>
        /// <param name="optionsBuilder">Будівельник, який використовується для створення або зміни параметрів для цього контексту.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=rosaka1429;Database=\"sykhiv gang\";Pooling=true;");


        /// <summary>
        /// Налаштовує модель, яка була виявлена за допомогою угоди з типами сутностей, відкритих у властивостях <see cref="DbSet{TEntity}"/> на вашому похідному контексті.
        /// </summary>
        /// <param name="modelBuilder">Будівельник, який використовується для побудови моделі для цього контексту.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("user_id")
                    .IsRequired();

                entity.Property(e => e.FirstName)
                    .HasColumnName("user_name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("user_surname")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
