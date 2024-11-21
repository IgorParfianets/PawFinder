using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using UserService.Domain.Abstractions.Repositories;
using UserService.Infrastructure.Repositories;

namespace UserService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        
        var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        
        return services;
    }
}