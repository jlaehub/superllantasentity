using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace superllantasEntity.Models;

public partial class SuperllantasContext : DbContext
{
    public SuperllantasContext()
    {
    }

    public SuperllantasContext(DbContextOptions<SuperllantasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//ning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("server=JUANAPODACA\\SQLEXPRESS; database=Superllantas; integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branches__751EBD5FDE2B6684");

            entity.Property(e => e.BranchId).HasColumnName("branchId");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            entity.HasOne(d => d.Company).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Branches__compan__398D8EEE");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Companie__AD54599071551C06");

            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7D2BCD82CC");

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E616403B2D34C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E61642653476E").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(50)
                .HasColumnName("customerType");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.SalesAdvisorId).HasColumnName("salesAdvisorId");
            entity.Property(e => e.SpecialDiscount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("specialDiscount");

            entity.HasOne(d => d.SalesAdvisor).WithMany(p => p.Customers)
                .HasForeignKey(d => d.SalesAdvisorId)
                .HasConstraintName("fk_salesAdvisorId");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__2D10D16AFF50B7C4");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.BranchId).HasColumnName("branchId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SalesTax)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("salesTax");
            entity.Property(e => e.WithholdingTax)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("withholdingTax");

            entity.HasOne(d => d.Branch).WithMany(p => p.Products)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Products__branch__49C3F6B7");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__FAE8F4F516509969");

            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.BranchId).HasColumnName("branchId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.SaleDate)
                .HasColumnType("date")
                .HasColumnName("saleDate");
            entity.Property(e => e.SaleType)
                .HasMaxLength(50)
                .HasColumnName("saleType");
            entity.Property(e => e.TemporaryDiscount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temporaryDiscount");

            entity.HasOne(d => d.Branch).WithMany(p => p.Sales)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK__Sales__branchId__46E78A0C");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sales__customerI__45F365D3");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF83FEF511");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61641EFD22B0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .HasColumnName("userType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
