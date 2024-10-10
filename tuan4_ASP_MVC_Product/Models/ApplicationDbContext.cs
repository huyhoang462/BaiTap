using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace tuan4_ASP_MVC_Product.Models;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Catalog> Catalogs { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=LAPTOP-TE90HW\\SQLEXPRESS;Database=QuanLySanPham;Trusted_Connection=True;Encrypt=False;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.CatalogCode).HasMaxLength(50);
                entity.Property(e => e.CatalogName).HasMaxLength(250);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductCode).HasMaxLength(50);
                entity.Property(e => e.ProductName).HasMaxLength(250);

                entity.HasOne(d => d.Catalog).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatalogId)
                    .HasConstraintName("FK_Product_Catalog");
            });

            OnModelCreatingPartial(modelBuilder);
        }

    public void OnModelCreatingPartial(ModelBuilder modelBuilder) { }
    }
