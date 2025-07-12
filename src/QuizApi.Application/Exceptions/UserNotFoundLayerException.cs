namespace QuizApi.Application.Exceptions;

public class UserNotFoundLayerException : ApplicationLayerException
{
    public UserNotFoundLayerException(Guid userId)
        : base(ErrorCodes.BadRequest, $"user with ID {userId} was not found.") { }
}