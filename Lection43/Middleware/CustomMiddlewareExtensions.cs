namespace Lection43.Middleware;

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCostomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseMiddleware<RequestResponseLoggingMiddleware>();
        return app;
    }
}
