using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class SykhivgangContext : DbContext
{
    public SykhivgangContext()
    {
    }

    public SykhivgangContext(DbContextOptions<SykhivgangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ammunition> Ammunitions { get; set; }

    public virtual DbSet<Brigade> Brigades { get; set; }

    public virtual DbSet<InventoryAmmunition> InventoryAmmunitions { get; set; }

    public virtual DbSet<InventoryWeapon> InventoryWeapons { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<SoldierAttrb> SoldierAttrbs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerAttrb> VolunteerAttrbs { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=sykhivgang;Username=postgres;Password=rosaka1429;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ammunition>(entity =>
        {
            entity.HasKey(e => e.AmmunitionId).HasName("ammunition_pkey");

            entity.ToTable("ammunition");

            entity.Property(e => e.AmmunitionId).HasColumnName("ammunition_id");
            entity.Property(e => e.AvailableAmount).HasColumnName("available_amount");
            entity.Property(e => e.Moneyneeded)
                .HasDefaultValueSql("0.0")
                .HasColumnName("moneyneeded");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NeededAmount).HasColumnName("needed_amount");
            entity.Property(e => e.Percentage)
                .HasDefaultValueSql("0.0")
                .HasColumnName("percentage");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Size)
                .HasMaxLength(20)
                .HasColumnName("size");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UsersGender)
                .HasMaxLength(10)
                .HasColumnName("users_gender");

            entity.HasOne(d => d.User).WithMany(p => p.Ammunitions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ammunition_user_id_fkey");
        });

        modelBuilder.Entity<Brigade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brigades_pkey");

            entity.ToTable("brigades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommanderName)
                .HasMaxLength(255)
                .HasColumnName("commander_name");
            entity.Property(e => e.EstablishmentDate).HasColumnName("establishment_date");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<InventoryAmmunition>(entity =>
        {
            entity.HasKey(e => e.InventoryAmmunitionId).HasName("inventory_ammunition_pkey");

            entity.ToTable("inventory_ammunition");

            entity.Property(e => e.InventoryAmmunitionId).HasColumnName("inventory_ammunition_id");
            entity.Property(e => e.AmmunitionId).HasColumnName("ammunition_id");
            entity.Property(e => e.BrigadeId).HasColumnName("brigade_id");
            entity.Property(e => e.GeneralAmmunition).HasColumnName("general_ammunition");
            entity.Property(e => e.StorageAmmunition).HasColumnName("storage_ammunition");

            entity.HasOne(d => d.Ammunition).WithMany(p => p.InventoryAmmunitions)
                .HasForeignKey(d => d.AmmunitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inventory_ammunition_ammunition_id_fkey");
        });

        modelBuilder.Entity<InventoryWeapon>(entity =>
        {
            entity.HasKey(e => e.InventoryWeaponId).HasName("inventory_weapon_pkey");

            entity.ToTable("inventory_weapon");

            entity.Property(e => e.InventoryWeaponId).HasColumnName("inventory_weapon_id");
            entity.Property(e => e.GeneralQuantity).HasColumnName("general_quantity");
            entity.Property(e => e.StorageQuantity).HasColumnName("storage_quantity");
            entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

            entity.HasOne(d => d.Weapon).WithMany(p => p.InventoryWeapons)
                .HasForeignKey(d => d.WeaponId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("inventory_weapon_weapon_id_fkey");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("requests_pkey");

            entity.ToTable("requests");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.AmmunitionId).HasColumnName("ammunition_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.QuantityRequested).HasColumnName("quantity_requested");
            entity.Property(e => e.ReceiverAdmin).HasColumnName("receiver_admin");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(20)
                .HasColumnName("request_status");
            entity.Property(e => e.SenterSoldier).HasColumnName("senter_soldier");
            entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

            entity.HasOne(d => d.Ammunition).WithMany(p => p.Requests)
                .HasForeignKey(d => d.AmmunitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("requests_ammunition_id_fkey");

            entity.HasOne(d => d.ReceiverAdminNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ReceiverAdmin)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("requests_receiver_admin_fkey");

            entity.HasOne(d => d.SenterSoldierNavigation).WithMany(p => p.Requests)
                .HasForeignKey(d => d.SenterSoldier)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("requests_senter_soldier_fkey");

            entity.HasOne(d => d.Weapon).WithMany(p => p.Requests)
                .HasForeignKey(d => d.WeaponId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("requests_weapon_id_fkey");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("routes_pkey");

            entity.ToTable("routes");

            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.AmmunitionId).HasColumnName("ammunition_id");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.DestinationPoint)
                .HasMaxLength(255)
                .HasColumnName("destination_point");
            entity.Property(e => e.QuantityDelivered).HasColumnName("quantity_delivered");
            entity.Property(e => e.StartingPoint)
                .HasMaxLength(255)
                .HasColumnName("starting_point");
            entity.Property(e => e.VolunteerId).HasColumnName("volunteer_id");
            entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

            entity.HasOne(d => d.Ammunition).WithMany(p => p.Routes)
                .HasForeignKey(d => d.AmmunitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("routes_ammunition_id_fkey");

            entity.HasOne(d => d.Volunteer).WithMany(p => p.Routes)
                .HasForeignKey(d => d.VolunteerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("routes_volunteer_id_fkey");

            entity.HasOne(d => d.Weapon).WithMany(p => p.Routes)
                .HasForeignKey(d => d.WeaponId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("routes_weapon_id_fkey");
        });

        modelBuilder.Entity<SoldierAttrb>(entity =>
        {
            entity.HasKey(e => e.SoldierAttrbId).HasName("soldier_attrb_pkey");

            entity.ToTable("soldier_attrb");

            entity.Property(e => e.SoldierAttrbId).HasColumnName("soldier_attrb_id");
            entity.Property(e => e.Callsign)
                .HasMaxLength(50)
                .HasColumnName("callsign");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.SoldierAttrbs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("soldier_attrb_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(255)
                .HasColumnName("user_surname");
        });

        modelBuilder.Entity<VolunteerAttrb>(entity =>
        {
            entity.HasKey(e => e.VolunteerAttrbId).HasName("volunteer_attrb_pkey");

            entity.ToTable("volunteer_attrb");

            entity.Property(e => e.VolunteerAttrbId).HasColumnName("volunteer_attrb_id");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.VolunteerAttrbs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("volunteer_attrb_user_id_fkey");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.WeaponId).HasName("weapon_pkey");

            entity.ToTable("weapon");

            entity.Property(e => e.WeaponId).HasColumnName("weapon_id");
            entity.Property(e => e.AvailableAmount).HasColumnName("available_amount");
            entity.Property(e => e.Moneyneeded)
                .HasDefaultValueSql("0.0")
                .HasColumnName("moneyneeded");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NeededAmount).HasColumnName("needed_amount");
            entity.Property(e => e.Percentage)
                .HasDefaultValueSql("0.0")
                .HasColumnName("percentage");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Weight)
                .HasPrecision(6, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.User).WithMany(p => p.Weapons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("weapon_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
