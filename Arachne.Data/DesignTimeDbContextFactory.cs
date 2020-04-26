using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Arachne.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ArachneContext> 
    { 
        public ArachneContext CreateDbContext(string[] args) 
        { 
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/../Arachne.API/local.settings.json")
                .Build(); 
            var builder = new DbContextOptionsBuilder<ArachneContext>(); 
            var connectionString = configuration.GetConnectionString("ArachneDatabase"); 
            builder.UseSqlServer(connectionString); 
            return new ArachneContext(builder.Options); 
        } 
    }
}