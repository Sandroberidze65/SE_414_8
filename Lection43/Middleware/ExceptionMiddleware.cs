using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lection43.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;

            _logger.LogError(
                ex,
                "Unhandled exception occured, Method: {Method}, Path: {Path}, TraceId: {TraceId}",
                context.Request.Method,
                context.Request.Path,
                context.TraceIdentifier
            );


            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var statusCode = ex switch
        {
            ArgumentException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var problemDetails = new ProblemDetails
        {
            Title = statusCode switch
            {
                400 => "Bad Request",
                404 => "Resource not Found",
                _ => "Internal Server Error"
            },
            Detail = statusCode == 500 ? "An Unhandled exception occured" : ex.Message,
            Status = statusCode,
            Instance = context.Request.Path
        };

        context.Response.ContentType = "application/Problem+json";
        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));

    }
}
