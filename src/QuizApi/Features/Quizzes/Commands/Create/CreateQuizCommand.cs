using MediatR;
using QuizApi.Infrastructure.Entities.Enums;

namespace QuizApi.Features.Quizzes.Commands.Create;

public record CreateQuizCommand (
        Guid CreatorId, 
        string Title,
        string? Description,
        QuizType QuizType,
        Visibility Visibility,
        string? AccessCode,
        bool IsAnonymousAllowed,
        int DurationMinutes
    ) : IRequest<Guid>;