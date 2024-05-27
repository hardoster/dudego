using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dudego.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBranch> TbBranches { get; set; }

    public virtual DbSet<TbCar> TbCars { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbInvoiceDetail> TbInvoiceDetails { get; set; }

    public virtual DbSet<TbSalesperson> TbSalespeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=dudegodb;Password=123;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("DUDEGODB")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<TbBranch>(entity =>
        {
            entity.HasKey(e => e.IdBranch).HasName("SYS_C0013030");

            entity.ToTable("TB_BRANCHES");

            entity.Property(e => e.IdBranch)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_BRANCH");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.NameBranch)
                .HasMaxLength(100)
                .HasColumnName("NAME_BRANCH");
            entity.Property(e => e.PhoneNumberBranch)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER_BRANCH");
        });

        modelBuilder.Entity<TbCar>(entity =>
        {
            entity.HasKey(e => e.IdCar).HasName("SYS_C0013027");

            entity.ToTable("TB_CARS");

            entity.Property(e => e.IdCar)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CAR");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("BRAND");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .HasColumnName("COLOR");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("MODEL");
            entity.Property(e => e.NumberPlate)
                .HasMaxLength(20)
                .HasColumnName("NUMBER_PLATE");
            entity.Property(e => e.Year)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("YEAR");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("SYS_C0013021");

            entity.ToTable("TB_CUSTOMER");

            entity.Property(e => e.IdCustomer)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CUSTOMER");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.DrivingLic)
                .HasMaxLength(50)
                .HasColumnName("DRIVING_LIC");
            entity.Property(e => e.DuiCustomer)
                .HasMaxLength(50)
                .HasColumnName("DUI_CUSTOMER");
            entity.Property(e => e.NameCustomer)
                .HasMaxLength(100)
                .HasColumnName("NAME_CUSTOMER");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("PHONE_NUMBER");
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.HasKey(e => e.IdInvoice).HasName("SYS_C0013037");

            entity.ToTable("TB_INVOICE");

            entity.Property(e => e.IdInvoice)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_INVOICE");
            entity.Property(e => e.IdBranch)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_BRANCH");
            entity.Property(e => e.IdCustomer)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CUSTOMER");
            entity.Property(e => e.IdSalesperson)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_SALESPERSON");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .HasColumnName("INVOICE_NUMBER");

            entity.HasOne(d => d.IdBranchNavigation).WithMany(p => p.TbInvoices)
                .HasForeignKey(d => d.IdBranch)
                .HasConstraintName("SYS_C0013039");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.TbInvoices)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("SYS_C0013038");

            entity.HasOne(d => d.IdSalespersonNavigation).WithMany(p => p.TbInvoices)
                .HasForeignKey(d => d.IdSalesperson)
                .HasConstraintName("SYS_C0013040");
        });

        modelBuilder.Entity<TbInvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.IdInvoiceDetails).HasName("SYS_C0013045");

            entity.ToTable("TB_INVOICE_DETAILS");

            entity.Property(e => e.IdInvoiceDetails)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_INVOICE_DETAILS");
            entity.Property(e => e.DayDuration)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DAY_DURATION");
            entity.Property(e => e.IdCar)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_CAR");
            entity.Property(e => e.IdInvoice)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_INVOICE");
            entity.Property(e => e.PriceDay)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRICE_DAY");
            entity.Property(e => e.RentalDeposit)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("RENTAL_DEPOSIT");

            entity.HasOne(d => d.IdCarNavigation).WithMany(p => p.TbInvoiceDetails)
                .HasForeignKey(d => d.IdCar)
                .HasConstraintName("SYS_C0013047");

            entity.HasOne(d => d.IdInvoiceNavigation).WithMany(p => p.TbInvoiceDetails)
                .HasForeignKey(d => d.IdInvoice)
                .HasConstraintName("SYS_C0013046");
        });

        modelBuilder.Entity<TbSalesperson>(entity =>
        {
            entity.HasKey(e => e.IdSalesperson).HasName("SYS_C0013034");

            entity.ToTable("TB_SALESPERSON");

            entity.Property(e => e.IdSalesperson)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID_SALESPERSON");
            entity.Property(e => e.CodeSalesperson)
                .HasMaxLength(50)
                .HasColumnName("CODE_SALESPERSON");
            entity.Property(e => e.NameSalesperson)
                .HasMaxLength(100)
                .HasColumnName("NAME_SALESPERSON");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
