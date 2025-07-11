using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApi.Infrastructure.Configurations;
using QuizApi.Infrastructure.Database;
using QuizApi.Infrastructure.Database.Postgres.Repository;

namespace QuizApi.Infrastructure;

public static class InfrastructureDependencies
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // database
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseNpgsql(configuration.GetConnectionString(nameof(Postgres)))
                .UseSnakeCaseNamingConvention(); 
        });

    }
}