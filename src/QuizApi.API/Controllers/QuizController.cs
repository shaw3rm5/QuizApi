using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApi.Application.Features.Quizzes.Commands.Create;

namespace QuizApi.Controllers;
[Route("/quiz")]
public class QuizController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuizController(
        IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("/quiz/create")]
    public async Task<IResult> CreateQuiz(
        [FromBody] CreateQuizCommand command)
    {
        var result = await _mediator.Send(command);
        return Results.Ok(result);
    }
}