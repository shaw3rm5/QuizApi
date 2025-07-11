namespace QuizApi.Infrastructure.Exceptions;

public abstract class DomainException  : Exception
{
    public ErrorCodes ErrorCode { get; }

    public DomainException(ErrorCodes errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}