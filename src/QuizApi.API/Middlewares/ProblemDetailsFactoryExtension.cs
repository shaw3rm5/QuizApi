using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuizApi.Application.Exceptions;

namespace QuizApi.Middlewares;

public static class ProblemDetailsFactoryExtension
{
    public static ProblemDetails CreateFrom(
        this ProblemDetailsFactory factory,
        HttpContext httpContext,
        ApplicationLayerException applicationLayerException)
    {
        return factory.CreateProblemDetails(httpContext, applicationLayerException.ErrorCode switch
        {
            ErrorCodes.Gone => StatusCodes.Status410Gone,   
            ErrorCodes.NotFound => StatusCodes.Status404NotFound,
            ErrorCodes.BadRequest => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError,
        }, applicationLayerException.Message);
        
        
    }

    public static ProblemDetails CreateFrom(this ProblemDetailsFactory factory, HttpContext httpContext,
        ValidationException validationException)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in validationException.Errors)
        {
            modelStateDictionary.AddModelError(error.PropertyName, error.ErrorCode);
        }
        return factory.CreateValidationProblemDetails(httpContext, modelStateDictionary,
            StatusCodes.Status400BadRequest,
            "Invalid Request", detail: validationException.Message);
    }
}