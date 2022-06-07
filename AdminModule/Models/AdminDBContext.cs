using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminModule.Models
{
    public partial class AdminDBContext : DbContext
    {
        public AdminDBContext()
        {
        }

        public AdminDBContext(DbContextOptions<AdminDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminCredentials> AdminCredentials { get; set; }
        public virtual DbSet<AirlineaddBlock> AirlineaddBlock { get; set; }
        public virtual DbSet<AirlineSchedule> AirlineSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET135;Database=AdminDB;User id =sa;password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminCredentials>(entity =>
            {
                entity.HasKey(e => e.Aid);

                entity.Property(e => e.Apassword)
                    .HasColumnName("APassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ausername)
                    .HasColumnName("AUsername")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AirlineaddBlock>(entity =>
            {
                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.AirlineId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Airlinename)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlockedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AirlineSchedule>(entity =>
            {
                entity.Property(e => e.AirlineId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EndDatetime)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Fromplace)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentUsed)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Meal)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduledDay)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StartDatetime)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Ticketcharge).HasColumnType("money");

                entity.Property(e => e.ToPlace)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
