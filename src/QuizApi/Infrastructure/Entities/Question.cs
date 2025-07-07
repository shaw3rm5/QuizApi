using QuizApi.Infrastructure.Entities.Enums;

namespace QuizApi.Infrastructure.Entities;

public class Question
{
    public Guid Id { get; private set; }
    public Guid QuizId { get; private set; }
    public string QuestionText { get; private set; } = null!;
    public QuestionType Type { get; private set; }
    
}