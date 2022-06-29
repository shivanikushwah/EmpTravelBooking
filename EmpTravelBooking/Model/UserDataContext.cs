using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmpTravelBooking.Model
{
    public partial class UserDataContext : DbContext
    {
        public UserDataContext()
        {
        }

        public UserDataContext(DbContextOptions<UserDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.\\sqlexpress;Trusted_Connection=True;Database=EmployeeTravelBooking");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__EMPLOYEE__1788CC4C895F1847");

                entity.ToTable("EMPLOYEE");

                entity.HasIndex(e => e.LoginId, "UQ__EMPLOYEE__4DDA2819EEA54C19")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "UQ__EMPLOYEE__87909B15800147F6")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LoginId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerUserId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ManagerUserID");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
