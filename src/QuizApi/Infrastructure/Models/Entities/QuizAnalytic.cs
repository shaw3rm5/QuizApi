namespace QuizApi.Infrastructure.Models.Entities;

public class QuizAnalytic : BaseEntity
{
    public Guid QuizId { get; private set; }
    public int TotalResponses { get; private set; }
    public double AverageCompletionTime { get; private set; }
    public double CompletionRate { get; private set; }
    public DateTimeOffset LastCalculatedAt { get; private set; }

    public Quiz Quiz { get; set; }
    
    public static QuizAnalytic Create(
        Guid quizId, int totalResponses, double averageCompletionTime,
        double completionRate)
    {
        return new QuizAnalytic
        {
            QuizId = quizId,
            TotalResponses = totalResponses,
            AverageCompletionTime = averageCompletionTime,
            CompletionRate = completionRate,
            LastCalculatedAt = DateTimeOffset.UtcNow,
        };
    }
    
    public void Update(int totalResponses, double averageTime, double rate)
    {
        TotalResponses = totalResponses;
        AverageCompletionTime = averageTime;
        CompletionRate = rate;
        LastCalculatedAt = DateTimeOffset.UtcNow;
    }
}