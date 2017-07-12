using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarWorkshop.Core.Models
{
    public partial class CarWorkshopContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

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

                entity.Property(e => e.Brand).HasMaxLength(64);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Model).HasMaxLength(64);

                entity.Property(e => e.RegistrationNumber).HasMaxLength(16);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Car__ClientID__6EF57B66");
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.PhoneNumber).HasColumnType("varchar(11)");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Client__UserRole__6A30C649");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Currency).HasMaxLength(4);

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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.PhoneNumber).HasColumnType("varchar(11)");

                entity.Property(e => e.UserRole).HasDefaultValueSql("2");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Position)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Employee__Positi__36B12243");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Employee__UserRo__6B24EA82");
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

                entity.Property(e => e.Payment).HasColumnType("money");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Repair__CarID__656C112C");

                entity.HasOne(d => d.DiscountNavigation)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.Discount)
                    .HasConstraintName("FK__Repair__Discount__6D0D32F4");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Repair)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Repair__Employee__37A5467C");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__UserRole__8AFACE3A5F18E033");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });
        }
    }
}