using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QuizApi.Application.Features.Quizzes.Commands.Create;

namespace QuizApi.Application;

public static class ApplicationDependencies
{
    public static void AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(CreateQuizCommand).Assembly));

        services.AddValidatorsFromAssemblyContaining<CreateCommandValidator>(includeInternalTypes: true);
    }
}