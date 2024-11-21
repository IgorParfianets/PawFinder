using Microsoft.Extensions.DependencyInjection;

namespace UserService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AdApplication(this IServiceCollection services)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
}