namespace QuizApi.Infrastructure.Entities;

public class Response
{
    public Guid Id { get; private set; }
    public Guid QuizId { get; private set; }
    public Guid? UserId { get; private set; }
    public Guid? SessionId { get; private set; } //for anon users
    public string IpAddressHash { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset CompletedAt { get; private set; }
    
    public Quiz Quiz { get; set; }
    public ICollection<ResponseAnswer> Answers { get; private set; } 

    public static Response Create(
        Guid quizId, string ipAddressHash, DateTimeOffset completedAt,
        Guid? userId = null, Guid? sessionId = null)
    {
        return new Response
        {
            Id = Guid.NewGuid(),
            QuizId = quizId,
            UserId = userId,
            SessionId = sessionId,
            IpAddressHash = ipAddressHash,
            CompletedAt = completedAt,
            CreatedAt = DateTimeOffset.UtcNow,
            Answers = new List<ResponseAnswer>() 
        };
    }
}