using QuizApi.Infrastructure.Entities.Enums;

namespace QuizApi.Infrastructure.Entities;

public class Question
{
    public Guid Id { get; private set; }
    public Guid QuizId { get; private set; }
    public string QuestionText { get; private set; } = null!;
    public QuestionType Type { get; private set; }
    public int OrderIndex { get; private set; }
    public bool IsRequired { get; private set; }
    public int TimeLimitSeconds { get; private set; }
    public string ImageUrl { get; private set; } = null!;
    
    public Quiz Quiz { get; set; }
    public ICollection<AnswerOption> AnswerOptions { get; private set; }

    public static Question Create(
            Guid quizId, string questionText, QuestionType type,
            int orderIndex, bool isRequired, int timeLimitSeconds, string imageUrl
        )
    {
        return new Question
        {
            Id = Guid.NewGuid(),
            QuizId = quizId,
            QuestionText = questionText,
            Type = type,
            OrderIndex = orderIndex,
            IsRequired = isRequired,
            TimeLimitSeconds = timeLimitSeconds,
            ImageUrl = imageUrl,
            AnswerOptions = new List<AnswerOption>()
        };
    }
}