using Demo.Entities;
using GrpcService1.Contexts;
using GrpcService1.Repository;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<DataBaseContext>();
        services.AddScoped<IRepository, GoogleRepository>();
        return services;
    }
}
