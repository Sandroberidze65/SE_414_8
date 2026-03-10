using Azure;

namespace Lection43.Middleware;

public class CostomMiddleware
{
    private readonly RequestDelegate _next;

    public CostomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync("\nBefore\n");

        await _next.Invoke(httpContext);

        await httpContext.Response.WriteAsync("\nAfter\n");

    }
}
