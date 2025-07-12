namespace QuizApi.Application.Exceptions;

public class QuizAlreadyExistsException : ApplicationException
{
    public QuizAlreadyExistsException(string quizName) 
        : base(ErrorCodes.BadRequest, $"quiz with name {quizName} already exists") { }
}