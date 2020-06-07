using Arachne.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Arachne.Data
{
    public class ArachneContext : DbContext
    {
        public ArachneContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Connection> Connections { get; set; }

        public virtual DbSet<PotentialConnection> PotentialConnections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.From)
                .WithMany(u => u.ConnectionsFrom)
                .IsRequired()
                .HasForeignKey(c => c.FromUserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.To)
                .WithMany(u => u.ConnectionsTo)
                .IsRequired()
                .HasForeignKey(c => c.ToUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PotentialConnection>()
                .HasOne(c => c.From)
                .WithMany(u => u.PotentialConnectionsFrom)
                .IsRequired()
                .HasForeignKey(c => c.FromUserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<PotentialConnection>()
                .HasOne(c => c.To)
                .WithMany(u => u.PotentialConnectionsTo)
                .IsRequired()
                .HasForeignKey(c => c.ToUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}