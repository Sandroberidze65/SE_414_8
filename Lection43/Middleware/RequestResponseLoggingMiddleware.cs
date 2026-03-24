using System.Diagnostics;

namespace Lection43.Middleware;

public class RequestResponseLoggingMiddleware
{
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public RequestResponseLoggingMiddleware(ILogger<RequestResponseLoggingMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        _logger.LogInformation(
            "Incoming request: {Method}, {Path} QueryString: {QueryString} TraceId: {TraceId}",
            context.Request.Method,
            context.Request.Path,
            context.Request.QueryString,
            context.TraceIdentifier
        );

        await _next(context);

        stopwatch.Stop();

        _logger.LogInformation(
            "Incoming response: {Method}, {Path} StatusCode: {StatusCode}, DurationMs: {DurationMs} TraceId: {TraceId}",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds,
            context.TraceIdentifier
        );

    }
}
