using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<BlazorApp3.Models.Device> Device { get; set; } = default!;
        public DbSet<BlazorApp3.Models.Transmitter> Transmitter { get; set; } = default!;
        public DbSet<BlazorApp3.Models.Receiver> Receiver { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Receiver>()
                .HasOne(r => r.Transmitter)
                .WithMany()
                .HasForeignKey("TransmitterId")
                .OnDelete(DeleteBehavior.Restrict) // Specify ON DELETE NO ACTION
                .IsRequired(false); // Allow null values
        }
    }
}
