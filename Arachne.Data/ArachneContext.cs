using Arachne.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Arachne.Data
{
    public class ArachneContext : DbContext
    {

            public ArachneContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        
            public virtual DbSet<User> Users { get; set; }

            public virtual DbSet<Connection> Connections { get; set; }
            
            public virtual DbSet<PotentialConnection> PotentialConnections { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }
    
}