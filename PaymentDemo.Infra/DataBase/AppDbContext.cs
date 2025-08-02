using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PaymentDemo.Models.DataBase;

namespace PaymentDemo.Infra.DataBase;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VwSaleDetail> VwSaleDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=demo_control.mssql.somee.com;Database=demo_control;User Id=SaulDuenas_SQLLogin_1;pwd=elmasmejor;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Products_Id");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Sales_Id");

            entity.ToTable("sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SaleDetails_Id");

            entity.ToTable("sale_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Product");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SaleDetail_Sale");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users_Id");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserName, "UQ_Users_UserName").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("fullName");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("passwordHash");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<VwSaleDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwSaleDetails");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.ProductName).HasMaxLength(150);
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(21, 2)");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
