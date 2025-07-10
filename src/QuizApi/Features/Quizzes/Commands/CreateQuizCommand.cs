using MediatR;
using QuizApi.Infrastructure.Entities.Enums;

namespace QuizApi.Features.Quizzes.Commands;

public record CreateQuizCommand (
        Guid CreatorId, 
        string Title,
        string? Description,
        QuizType QuizType,
        Visibility Visibility
    ) : IRequest<Guid>;