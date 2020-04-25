using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Arachne.API.Settings
{
    public static class SettingsChecker
    {
        public static void CheckSettings(IConfigurationRoot config)
        {
            CheckConnectionStrings(config);
            CheckLocalSettings(config);
        }
        
        private static void CheckConnectionStrings(IConfiguration config)
        {
            var connectionStrings = config.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            if (string.IsNullOrEmpty(connectionStrings?.ArachneDatabase))
            {
                throw new MissingFieldException("Missing connection string for Database");
            }
        }
        private static void CheckLocalSettings(IConfiguration config)
        {
            var settings = config.Get(typeof(AppSettings));
            var missingSettings = settings.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Where(s => string.IsNullOrEmpty((string) s.GetValue(settings)))
                .Select(s => s.Name);

            var missingSettingsString = string.Join(", ", missingSettings);
            if (missingSettingsString.Length > 0)
            {
                throw new MissingFieldException(
                    $"Missing value for key {missingSettingsString} in local.settings.json. " +
                    "The application will not start.");
            }
        }
    }
}