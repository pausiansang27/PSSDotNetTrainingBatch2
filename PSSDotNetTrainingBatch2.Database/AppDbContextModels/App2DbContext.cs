using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PSSDotNetTrainingBatch2.Database.AppDbContextModels;

public partial class App2DbContext : DbContext
{
    public App2DbContext()
    {
    }

    public App2DbContext(DbContextOptions<App2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSale> TblSales { get; set; }

    public virtual DbSet<TblSaleDetail> TblSaleDetails { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Database=DotNetTrainingBatch2;User ID=sa;Password=sasa@123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BlogId).ValueGeneratedOnAdd();
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Tbl_Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblSale>(entity =>
        {
            entity.HasKey(e => e.SaleId);

            entity.ToTable("Tbl_Sale");

            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblSaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId);

            entity.ToTable("Tbl_SaleDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Tbl_student");

            entity.Property(e => e.StudentId).HasColumnName("studentId");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
