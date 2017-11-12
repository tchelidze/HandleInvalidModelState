using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace HandleInvalidModelState.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HandleInvalidModelWithRedirectActionFilterAttribute : InvalidModelStateActionFilterBase
    {
        private readonly string _redirectUrl;

        public HandleInvalidModelWithRedirectActionFilterAttribute(string redirectUrl)
            => _redirectUrl = redirectUrl;

        public override Task OnActionWithInvalidModelStateExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            context.Result = new RedirectResult(_redirectUrl, false);
            return Task.CompletedTask;
        }
    }
}