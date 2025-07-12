namespace QuizApi.Application.Exceptions;

public class UserNotFoundException : ApplicationException
{
    public UserNotFoundException(Guid userId)
        : base(ErrorCodes.BadRequest, $"user with ID {userId} was not found.") { }
}