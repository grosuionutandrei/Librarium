using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.services;
using Microsoft.Extensions.DependencyInjection;

namespace Librarium.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<ILoansService, LoanService>();
        return services;
    }
}