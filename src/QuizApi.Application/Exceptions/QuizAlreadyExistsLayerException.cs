namespace QuizApi.Application.Exceptions;

public class QuizAlreadyExistsLayerException : ApplicationLayerException
{
    public QuizAlreadyExistsLayerException(string quizName) 
        : base(ErrorCodes.BadRequest, $"quiz with name {quizName} already exists") { }
}