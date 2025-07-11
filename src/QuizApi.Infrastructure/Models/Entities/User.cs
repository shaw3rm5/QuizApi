namespace QuizApi.Infrastructure.Models.Entities;

public class User : BaseEntity
{
    public string UserName { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    
    public ICollection<Quiz> Quizzes { get; private set; }

    public static User Create(string userName, string passwordHash, string email)
    {
        return new User
        {
            UserName = userName,
            PasswordHash = passwordHash,
            Email = email,
            Quizzes = new List<Quiz>()
        };
    }
}