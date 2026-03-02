using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Librarium.Data.infrastructure.configuration;

    public static class AppOptionsExtension
    {
        public static AppInfrastructureOptions AddInfrastructureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var appOptions = new AppInfrastructureOptions();
            configuration.GetSection("AppInfrastructureOptions").Bind(appOptions);
            services.Configure<AppInfrastructureOptions>(configuration.GetSection("AppInfrastructureOptions"));
            return appOptions;
        }
    }

