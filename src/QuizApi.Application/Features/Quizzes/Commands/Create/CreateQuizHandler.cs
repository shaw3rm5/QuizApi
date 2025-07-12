using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApi.Application.Exceptions;
using QuizApi.Infrastructure.Database.Postgres.Repository;
using QuizApi.Infrastructure.Models.Entities;

namespace QuizApi.Application.Features.Quizzes.Commands.Create;

public class CreateQuizHandler : IRequestHandler<CreateQuizCommand, Guid>
{
    private readonly IValidator<CreateQuizCommand> _validator;
    private readonly IRepository<Quiz> _quizRepository;
    private readonly IRepository<User> _userRepository;

    public CreateQuizHandler(
        IValidator<CreateQuizCommand> validator,
        IRepository<Quiz> quizRepository,
        IRepository<User> userRepository)
    {
        _validator = validator;
        _quizRepository = quizRepository;
        _userRepository = userRepository;
    }
    
    public async Task<Guid> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var existQuiz = await _quizRepository
            .Where(u => u.Title == request.Title)
            .SingleOrDefaultAsync(cancellationToken);
        
        var user = await _userRepository
            .Where(u => u.Id == request.AuthorId)
            .SingleOrDefaultAsync(cancellationToken);

        if (user is null)
            throw new UserNotFoundLayerException(request.AuthorId);

        if (existQuiz is not null)
            throw new QuizAlreadyExistsLayerException(request.Title);
        
        var quiz = Quiz.Create(
            request.AuthorId,
            request.Title,
            request.Description,
            request.QuizType,
            request.Visibility,
            request.AccessCode,
            request.IsAnonymousAllowed,
            request.DurationMinutes);
        
        await _quizRepository.AddAsync(quiz, cancellationToken);
        await _quizRepository.SaveChangesAsync(cancellationToken);
        
        return quiz.Id;
    }
}