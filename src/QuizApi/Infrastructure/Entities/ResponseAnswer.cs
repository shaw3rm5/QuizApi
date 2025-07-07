namespace QuizApi.Infrastructure.Entities;

public class ResponseAnswer
{
    public Guid Id { get; private set; }
    public Guid ResponseId { get; private set; }
    public Guid QuestionId { get; private set; }
    public Guid[] SelectedAnswerIds { get; private set; } = null!;
    public string? TextAnswer { get; private set; }
    public int RatingValue { get; private set; }
    public DateTimeOffset AnsweredAt { get; private set; }
    
    public Response Response { get; set; }
    public Question Question { get; set;}

    public static ResponseAnswer Create(
            Guid responseId, Guid questionId, Guid[] selectedAnswerIds,
            string textAnswer, int ratingValue, DateTimeOffset answeredAt)
    {
        return new ResponseAnswer
        {
            Id = Guid.NewGuid(),
            ResponseId = responseId,
            QuestionId = questionId,
            SelectedAnswerIds = selectedAnswerIds,
            TextAnswer = textAnswer,
            RatingValue = ratingValue,
            AnsweredAt = answeredAt,
        };
    }
}