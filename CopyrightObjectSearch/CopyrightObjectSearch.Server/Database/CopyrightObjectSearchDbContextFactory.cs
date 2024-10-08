using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace CopyrightObjectSearch.Server.Database
{
    public class CopyrightObjectSearchDbContextFactory : IDesignTimeDbContextFactory<CopyrightObjectSearchDbContext>
    {

        public CopyrightObjectSearchDbContext CreateDbContext(string[] args)

        {

            var optionsBuilder = new DbContextOptionsBuilder<CopyrightObjectSearchDbContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CopyrightObjectSearch");

            optionsBuilder.UseSqlServer(connectionString);

            return new CopyrightObjectSearchDbContext(optionsBuilder.Options);

        }

    }

}
