using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToDoList.WebApi.Middleware;

public class ErrorHandlerMiddleware : IMiddleware
{
    private const string UnhandledExceptionMsg = "An unhandled exception has occurred while executing the request.";

    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, UnhandledExceptionMsg);

            const string contentType = "application/problem+json";
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = contentType;

            var problemDetails = CreateProblemDetails(context, exception);
            var json = ToJson(problemDetails);
            await context.Response.WriteAsync(json);
        }
    }

    private ProblemDetails CreateProblemDetails(in HttpContext context, in Exception exception)
    {
        var statusCode = context.Response.StatusCode;
        var reasonPhrase = ReasonPhrases.GetReasonPhrase(statusCode);
        if (string.IsNullOrEmpty(reasonPhrase))
        {
            reasonPhrase = UnhandledExceptionMsg;
        }

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = reasonPhrase,
        };

        problemDetails.Detail = exception.ToString();
        problemDetails.Extensions["traceId"] = context.TraceIdentifier;
        problemDetails.Extensions["data"] = exception.Data;

        return problemDetails;
    }

    private string ToJson(in ProblemDetails problemDetails)
    {
        try
        {
            return JsonSerializer.Serialize(problemDetails, SerializerOptions);
        }
        catch (Exception ex)
        {
            const string msg = "An exception has occurred while serializing error to JSON.";
            _logger.LogError(ex, msg);
        }

        return string.Empty;
    }
}