using QuizApi.Infrastructure.Entities.Enums;

namespace QuizApi.Infrastructure.Models.Entities;

public class Quiz : BaseEntity
{
    public Guid AuthorId { get; private set; }
    
    public string Title { get; private set; } = null!;
    public string? Description { get; private set; }
    
    public QuizType Type { get; private set; }
    public Visibility Visibility { get; private set; }
    public string? AccessCode { get; private set; }
    public bool IsAnonymousAllowed { get; set; }

    public int DurationMinutes { get; set; }
    public bool IsActive { get; private set; }
    
    public DateTimeOffset CreatedAt { get; private set; }
    
    public ICollection<Question> Questions { get; private set; }
    public ICollection<Response> Responses { get; private set; }
    
    public User Author { get; set; } = null!;
    
    public static Quiz Create(
            Guid creatorId, string title, string? description,
            QuizType type,  Visibility visibility, string? accessCode, 
            bool isAnonymousAllowed, int durationMinutes)
    {
        return new Quiz
        {
            AuthorId = creatorId,
            Title = title,
            Description = description,
            Type = type,
            Visibility = visibility,
            AccessCode = accessCode,
            DurationMinutes = durationMinutes,
            IsAnonymousAllowed = isAnonymousAllowed,
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            Questions = new List<Question>(),
            Responses = new List<Response>()
        };
    }
    
}