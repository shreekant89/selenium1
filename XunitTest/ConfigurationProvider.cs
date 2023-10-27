using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace XunitTest
{
    public class ConfigurationProvider
    {

        public IConfiguration Configuration { get; }

        public ConfigurationProvider()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = configBuilder.Build(); 
        }
    }
}
