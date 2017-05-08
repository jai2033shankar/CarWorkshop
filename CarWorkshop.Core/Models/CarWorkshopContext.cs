using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarWorkshop.Core.Models
{
    public partial class CarWorkshopContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarBrand> CarBrand { get; set; }
        public virtual DbSet<CarModel> CarModel { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-FQTL9LU;Database=CarWorkshop;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.RegistrationNumber).HasMaxLength(16);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Car__BrandID__33D4B598");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Car__ClientID__38996AB5");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__Car__ModelID__34C8D9D1");
            });

            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__CarBrand__DAD4F3BE12677A55");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.ModelId)
                    .HasName("PK__CarModel__E8D7A1CCB5C071BF");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.CarModel)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__CarModel__BrandI__398D8EEE");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.EmailAddress).HasColumnType("varchar(100)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.IdentityCardNumber)
                    .IsRequired()
                    .HasColumnType("varchar(9)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.PhoneNumber).HasColumnType("varchar(11)");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmailAddress).HasColumnType("varchar(100)");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.IdentityCardNumber)
                    .IsRequired()
                    .HasColumnType("varchar(9)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.PhoneNumber).HasColumnType("varchar(11)");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Position)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Employee__Positi__36B12243");

                entity.HasOne(d => d.SalaryNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Salary)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Employee__Salary__35BCFE0A");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Repair>(entity =>
            {
                entity.Property(e => e.RepairId).HasColumnName("RepairID");

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Repair__Employee__37A5467C");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.Salary1)
                    .HasColumnName("Salary")
                    .HasColumnType("smallmoney");
            });
        }
    }
}