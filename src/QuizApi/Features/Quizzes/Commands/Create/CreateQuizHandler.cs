using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApi.Infrastructure.Database.Postgres.Repository;
using QuizApi.Infrastructure.Models.Entities;

namespace QuizApi.Features.Quizzes.Commands.Create;

public class CreateQuizHandler : IRequestHandler<CreateQuizCommand, Guid>
{
    private readonly IValidator<CreateQuizCommand> _validator;
    private readonly IRepository<Quiz> _quizRepository;

    public CreateQuizHandler(
        IValidator<CreateQuizCommand> validator,
        IRepository<Quiz> quizRepository)
    {
        _validator = validator;
        _quizRepository = quizRepository;
    }
    
    public async Task<Guid> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var existQuiz = await _quizRepository
            .Where(u => u.Title == request.Title)
            .SingleOrDefaultAsync(cancellationToken);

        if (existQuiz is null)
            return Guid.Empty;
        
        var quiz = Quiz.Create(
                request.CreatorId,
                request.Title,
                request.Description,
                request.QuizType,
                request.Visibility,
                request.AccessCode,
                request.IsAnonymousAllowed,
                request.DurationMinutes);
        return quiz.Id;
    }
}