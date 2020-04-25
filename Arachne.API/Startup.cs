using System;
using Arachne.API;
using Arachne.API.Repositories;
using Arachne.API.Repositories.Interfaces;
using Arachne.API.Settings;
using Arachne.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]

namespace Arachne.API
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            ConfigureBuilder(builder, config);
            SettingsChecker.CheckSettings(config);

            var connectionStrings = config.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            builder.Services.AddDbContext<ArachneContext>(
                options => options.UseSqlServer(connectionStrings.ArachneDatabase));
        }

        private static void ConfigureBuilder(IWebJobsBuilder builder, IConfiguration config)
        {
            builder.Services.AddOptions();
            builder.Services.Configure<AppSettings>(config);
            builder.Services.Configure<ConnectionStrings>(config.GetSection("ConnectionStrings"));

            AddRepositories(builder);
        }

        private static void AddRepositories(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        }
    }
}