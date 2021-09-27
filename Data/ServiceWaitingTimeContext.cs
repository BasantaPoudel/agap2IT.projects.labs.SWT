using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace agap2it.projects.labs.SWT.Data
{
    public partial class ServiceWaitingTimeContext : DbContext
    {
        public ServiceWaitingTimeContext()
        {
        }

        public ServiceWaitingTimeContext(DbContextOptions<ServiceWaitingTimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bu> buses { get; set; }
        public virtual DbSet<BusStation> BusStations { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Trajectory> Trajectories { get; set; }
        public virtual DbSet<TrajectoryStation> TrajectoryStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-97TUNA1;Database=ServiceWaitingTime;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bu>(entity =>
            {
                entity.ToTable("Bus");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Uuid).HasColumnName("uuid");
            });

            modelBuilder.Entity<BusStation>(entity =>
            {
                entity.HasKey(e => new { e.BusId, e.StationId });

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.BusStations)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusStations_Bus");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.NextStationId });

                entity.ToTable("Station");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BusStation)
                    .WithOne(p => p.Station)
                    .HasForeignKey<Station>(d => new { d.Id, d.NextStationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Station_BusStations");

                entity.HasOne(d => d.TrajectoryStation)
                    .WithOne(p => p.Station)
                    .HasForeignKey<Station>(d => new { d.Id, d.NextStationId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Station_TrajectoryStations");
            });

            modelBuilder.Entity<Trajectory>(entity =>
            {
                entity.ToTable("Trajectory");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TrajectoryStation>(entity =>
            {
                entity.HasKey(e => new { e.TrajectoryId, e.StationId });

                entity.Property(e => e.TrajectoryId).HasColumnName("trajectoryId");

                entity.HasOne(d => d.Trajectory)
                    .WithMany(p => p.TrajectoryStations)
                    .HasForeignKey(d => d.TrajectoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrajectoryStations_Trajectory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
