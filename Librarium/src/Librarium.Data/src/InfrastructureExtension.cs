using Librarium.Data.infrastructure;
using Librarium.Data.infrastructure.configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Librarium.Data
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddDataSourceAndRepositories(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
                {
                    var optionsMonitor = serviceProvider.GetRequiredService<IOptionsMonitor<AppInfrastructureOptions>>();
                    var connectionString = optionsMonitor.CurrentValue.ConnectionString;
                    options.UseSqlServer(connectionString);
                    options.EnableSensitiveDataLogging();
                }
            );
            return services;
        }
    }
}