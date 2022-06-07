using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserModule.Usermodel
{
    public partial class FlightsContext : DbContext
    {
        public FlightsContext()
        {
        }

        public FlightsContext(DbContextOptions<FlightsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<TblAirlines> TblAirlines { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TicketBooking> TicketBooking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET135;Database=Flights;user id =sa; password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAirlines>(entity =>
            {
                entity.HasKey(e => e.Flightnumber);

                entity.Property(e => e.Destination)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.FinalTicketprice).HasColumnType("money");

                entity.Property(e => e.Flightlogo).IsUnicode(false);

                entity.Property(e => e.Flightname)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Flighttime).HasColumnType("datetime");

                entity.Property(e => e.Oneway)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OnewayPrice).HasColumnType("money");

                entity.Property(e => e.Place)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Roundtrip)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sourse)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TwowayPrice).HasColumnType("money");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.Property(e => e.EmailId).HasMaxLength(200);

                entity.Property(e => e.OptNonveg)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OptVeg)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Page).HasColumnName("PAge");

                entity.Property(e => e.Pgender)
                    .HasColumnName("PGender")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pname)
                    .HasColumnName("PName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pnrstatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SelectedSeatNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TicketBooking>(entity =>
            {
                entity.Property(e => e.Bookingdate).HasColumnType("datetime");

                entity.Property(e => e.Optformeal)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerEmail).HasMaxLength(200);

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Seatnumbers)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
