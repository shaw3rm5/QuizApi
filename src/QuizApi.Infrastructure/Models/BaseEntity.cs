namespace QuizApi.Infrastructure.Models;

public abstract class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}