namespace QuizApi.Application.Exceptions;

public abstract class ApplicationException  : Exception
{
    public ErrorCodes ErrorCode { get; }

    public ApplicationException(ErrorCodes errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}