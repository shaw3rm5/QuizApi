using Microsoft.EntityFrameworkCore;
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
                .UseNpgsql(configuration.GetConnectionString("Postgres"))
                .UseSnakeCaseNamingConvention();
        });

    }
}