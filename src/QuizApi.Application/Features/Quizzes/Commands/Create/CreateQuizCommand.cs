using MediatR;
using QuizApi.Infrastructure.Models.Enums;

namespace QuizApi.Application.Features.Quizzes.Commands.Create;

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