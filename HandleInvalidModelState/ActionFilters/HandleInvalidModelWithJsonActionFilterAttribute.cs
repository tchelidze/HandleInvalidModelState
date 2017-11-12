using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HandleInvalidModelState.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HandleInvalidModelWithJsonActionFilterAttribute : InvalidModelStateActionFilterBase
    {
        private readonly Type _jsonResultFormatterType;

        public HandleInvalidModelWithJsonActionFilterAttribute(Type jsonResultFormatterType = null)
            => _jsonResultFormatterType = jsonResultFormatterType;

        public override Task OnActionWithInvalidModelStateExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var resultFormatter =
                _jsonResultFormatterType == null
                    ? new DefaultJsonResultFormatter()
                    : (IJsonResultFormatter)context.HttpContext.RequestServices.GetService(_jsonResultFormatterType);
            var viewModel = context.ActionArguments.First().Value;
            context.Result = resultFormatter.Format(viewModel, context.ModelState);
            return Task.CompletedTask;
        }
    }
}