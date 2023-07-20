using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LibraryWebApp.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("D:\\Projects\\LibraryWebAppProject\\LibraryWebApp\\backend\\LibraryWebApp.API\\appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseNpgsql(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("LibraryWebApp.Infrastructure"));

            return new AppDbContext(builder.Options);
        }
    }
}
