﻿﻿using Librarium.Data.infrastructure;
using Librarium.Data.infrastructure.configuration;
using Librarium.Data.infrastructure.repositories;
using Librarium.Services.application_services.ports;
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
            
            // Register repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ILoanRepository, LoansRepository>();
            
            return services;
        }
    }
}


