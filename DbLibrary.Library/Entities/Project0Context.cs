using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbLibrary.Library.Entities
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Basket_Product");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.ReceiptId)
                    .HasConstraintName("FK_Basket_Receipt");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Inventory_Location");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Inventory_Product");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductDescription).HasMaxLength(200);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitCost).HasColumnType("money");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.Property(e => e.ReceiptTimestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Receipt_Customer");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Receipt_Location");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
