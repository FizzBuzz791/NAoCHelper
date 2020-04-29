using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace NAoCHelper
{
    public static class Helpers
    {
        public static string GetCookie(string userSecretsId)
        {
            if (string.IsNullOrWhiteSpace(userSecretsId))
                throw new ArgumentNullException(nameof(userSecretsId), $"The {nameof(userSecretsId)} parameter should match the Guid found in your csproj file.");

            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", false, true)
                            .AddUserSecrets(userSecretsId);
            var config = builder.Build();

            var secretValues = config.GetSection("Secrets").GetChildren();
            return secretValues.FirstOrDefault(s => s.Key == "Cookie")?.Value ?? string.Empty;
        }
    }
}