using LibraryWebApp.Application.Services;
using LibraryWebApp.Domain.Interfaces.Repository;
using LibraryWebApp.Domain.Interfaces.Services;
using LibraryWebApp.Infrastructure.Data;
using LibraryWebApp.Infrastructure.Data.Repository;
using LibraryWebApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination"));
    });

        public static void ConfigureIISIntegration(this IServiceCollection servicces) =>
            servicces.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
    }
}
