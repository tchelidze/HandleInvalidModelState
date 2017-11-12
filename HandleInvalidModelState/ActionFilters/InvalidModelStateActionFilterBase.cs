using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HandleInvalidModelState.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class InvalidModelStateActionFilterBase : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
                return;
            }

            await OnActionWithInvalidModelStateExecutionAsync(context, next);
        }

        public abstract Task OnActionWithInvalidModelStateExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next);
    }
}