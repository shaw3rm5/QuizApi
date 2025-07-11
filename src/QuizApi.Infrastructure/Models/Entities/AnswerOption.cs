namespace QuizApi.Infrastructure.Models.Entities;

public class AnswerOption : BaseEntity
{ 
    public Guid QuestionId { get; private set; }
    public string OptionText { get; private set; }
    public int OrderIndex { get; private set; }
    public bool IsCorrect { get; private set; }

    public Question Question { get; private set; }
    
    public static AnswerOption Create(Guid questionId, string optionText, int orderIndex, bool? isCorrect)
    {
        return new AnswerOption
        {
            QuestionId = questionId,
            OptionText = optionText,
            OrderIndex = orderIndex,
            IsCorrect = isCorrect != null
        };
    }
}