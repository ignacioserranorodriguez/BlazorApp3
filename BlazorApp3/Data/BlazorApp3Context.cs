using Microsoft.EntityFrameworkCore;
using BlazorApp3.Models;

namespace BlazorApp3.Data
{
    public class BlazorApp3Context : DbContext
    {
        public BlazorApp3Context(DbContextOptions<BlazorApp3Context> options)
            : base(options)
        {
        }

        public DbSet<Device> Device { get; set; } = default!;
        public DbSet<Transmitter> Transmitter { get; set; } = default!;
        public DbSet<Receiver> Receiver { get; set; } = default!;
        public DbSet<Profile> Profile { get; set; } = default!;
        public DbSet<Connection> Connection { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Name).HasColumnType("varchar(255)").IsRequired();
                entity.Property(e => e.Ip).HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Receiver>()
                .HasOne(r => r.Transmitter)
                .WithMany()
                .HasForeignKey("TransmitterId")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}