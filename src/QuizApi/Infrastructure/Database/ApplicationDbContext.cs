using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.Database.Configurations;

namespace QuizApi.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionConfiguration).Assembly);
}