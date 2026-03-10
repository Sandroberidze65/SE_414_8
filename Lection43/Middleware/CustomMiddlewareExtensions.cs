using Microsoft.AspNetCore.Builder;

namespace Lection43.Middleware;

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseCostomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CostomMiddleware>();
    }
}
