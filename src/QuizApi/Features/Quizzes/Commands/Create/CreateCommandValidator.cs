using FluentValidation;
using QuizApi.Infrastructure.Database.Constants;

namespace QuizApi.Features.Quizzes.Commands.Create;

public class CreateCommandValidator : AbstractValidator<CreateQuizCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(q => q.Title)
            .MinimumLength(3)
            .MaximumLength(QuizConstants.TITLE_MAX_LENGTH)
            .NotEmpty()
            .WithMessage("Invalid Title Size");
        RuleFor(q => q.Description)
            .MaximumLength(QuizConstants.DESCRIPTION_MAX_LENGTH)
            .WithMessage("Invalid Description Size");
        RuleFor(q => q.AccessCode)
            .MaximumLength(QuizConstants.ACCESCODE_MAX_LENGTH)
            .WithMessage("Invalid AccessCode");
        RuleFor(q => q.DurationMinutes)
            .NotNull()
            .Must(x => x < 90)
            .WithMessage("Invalid Duration Minutes");
    }
}