using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FreeWheel.Models
{
    public partial class FreeWheelDBContext : DbContext
    {
        public FreeWheelDBContext()
        {
        }

        public FreeWheelDBContext(DbContextOptions<FreeWheelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cells> Cells { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<MarketPop> MarketPop { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Station> Station { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FreeWheelDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cells>(entity =>
            {
                entity.HasKey(e => e.CellId);

                entity.ToTable("CELLS");

                entity.Property(e => e.CellId)
                    .HasColumnName("CELL_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cell)
                    .HasColumnName("CELL")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.ToTable("MARKET");

                entity.Property(e => e.MarketId)
                    .HasColumnName("MARKET_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarketName)
                    .HasColumnName("MARKET_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarketPop>(entity =>
            {
                entity.HasKey(e => new { e.MarketId, e.CellId });

                entity.ToTable("MARKET_POP");

                entity.Property(e => e.MarketId).HasColumnName("MARKET_ID");

                entity.Property(e => e.CellId).HasColumnName("CELL_ID");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable("PROGRAM");

                entity.Property(e => e.ProgramId)
                    .HasColumnName("PROGRAM_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FlightDate)
                    .HasColumnName("FLIGHT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProgramName)
                    .HasColumnName("PROGRAM_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StationId).HasColumnName("STATION_ID");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("STATION");

                entity.Property(e => e.StationId)
                    .HasColumnName("STATION_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StationName)
                    .HasColumnName("STATION_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
