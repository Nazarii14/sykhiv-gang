using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data
{
    class MilitaryProjectContextFactory : IDbContextFactory<MilitaryProjectContext>
    {
        public MilitaryProjectContext CreateDbContext()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("ConnectionString.NpgSql");
            if (connectionString == null)
            {
                Console.WriteLine("NO CONNECTION STRING");
            }
            
            var builder = new DbContextOptionsBuilder<MilitaryProjectContext>();
            return new MilitaryProjectContext(builder.Options);
        }
    }
}
