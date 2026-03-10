using Microsoft.AspNetCore.Mvc.Filters;

namespace Lection43.Filters;

public class LogFilter : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("Before action");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("After action");
    }
}
