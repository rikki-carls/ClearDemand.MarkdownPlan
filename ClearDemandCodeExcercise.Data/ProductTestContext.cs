using System;
using System.Collections.Generic;
using ClearDemandCodeExcercise.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ClearDemandCodeExcercise.Data;

public partial class ProductTestContext : DbContext
{
    public ProductTestContext()
    {
    }

    public ProductTestContext(DbContextOptions<ProductTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MarkdownPlan> MarkdownPlans { get; set; }

    public virtual DbSet<MarkdownRule> MarkdownRules { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStorage> ProductStorages { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=cleardemandtest.cnm9ggxlc1hi.us-east-2.rds.amazonaws.com;uid=;pwd=;database=ProductTest");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MarkdownPlan>(entity =>
        {
            entity.HasKey(e => e.MarkdownPlanId).HasName("PRIMARY");

            entity.ToTable("MarkdownPlan");

            entity.HasIndex(e => e.ProductId, "FK_MarkdownPlan_Product_idx");

            entity.Property(e => e.MarkdownPlanId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.MarkdownPlans)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarkdownPlan_Product");

         
        });

        modelBuilder.Entity<MarkdownRule>(entity =>
        {
            entity.HasKey(e => e.MarkdownRuleId).HasName("PRIMARY");

            entity.ToTable("MarkdownRule");

            entity.HasIndex(e => e.MarkdownPlanId, "FK_MarkdownRule_MarkdownPlan_idx");

            entity.Property(e => e.MarkdownRuleId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.MarkdownPlanId)
                .HasMaxLength(16)
                .IsFixedLength();

            entity.HasOne(d => d.MarkdownPlan).WithMany(p => p.MarkdownRules)
                .HasForeignKey(d => d.MarkdownPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MarkdownRule_MarkdownPlan");


            
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductId, "ProductId_UNIQUE").IsUnique();

            entity.Property(e => e.ProductId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.Cost).HasPrecision(12);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Price).HasPrecision(12);
            entity.Property(e => e.Sku).HasMaxLength(45);
        });

        modelBuilder.Entity<ProductStorage>(entity =>
        {
            entity.HasKey(e => e.ProductStorageId).HasName("PRIMARY");

            entity.ToTable("ProductStorage");

            entity.HasIndex(e => e.ProductId, "FK_Product_ProductStorage_idx");

            entity.Property(e => e.ProductStorageId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.Location).HasMaxLength(45);
            entity.Property(e => e.ProductId)
                .HasMaxLength(16)
                .IsFixedLength();

            entity.HasOne(d => d.Product).WithMany(p => p.ProductStorages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductStorage");
        });


        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PRIMARY");

            entity.ToTable("Sale");

            entity.HasIndex(e => e.SaleId, "SaleId_UNIQUE").IsUnique();

            entity.Property(e => e.SaleId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.Cost).HasPrecision(12);
            entity.Property(e => e.Quantity);
            entity.Property(e => e.SaleDate)
;           entity.Property(e => e.AdjustedPrice).HasPrecision(12);

            entity.HasOne(d => d.MarkdownPlan).WithMany(p => p.Sales)
             .HasForeignKey(d => d.MarkdownPlanId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_Sales_MarkdownPlan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
