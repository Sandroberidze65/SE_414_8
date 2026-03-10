using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Lection43.Filters;

public class TimerFilter : IAsyncActionFilter
{
    private ILogger<TimerFilter> _logger;

    public TimerFilter(ILogger<TimerFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        _logger.LogInformation($"Action {context.ActionDescriptor} started");

        await next.Invoke();

        stopwatch.Stop();

        _logger.LogInformation($"Action {context.ActionDescriptor} completed");
        _logger.LogInformation($"{context.ActionDescriptor} run for {stopwatch.Elapsed} ");
    }
}
