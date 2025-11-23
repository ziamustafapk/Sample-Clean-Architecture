using Microsoft.Extensions.DependencyInjection;

namespace SampleCleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAutomapperRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}