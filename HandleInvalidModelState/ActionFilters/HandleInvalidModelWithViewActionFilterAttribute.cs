using HandleInvalidModelState.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HandleInvalidModelState.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HandleInvalidModelWithViewActionFilterAttribute : InvalidModelStateActionFilterBase
    {
        private readonly Type _viewModelInitializerType;

        public HandleInvalidModelWithViewActionFilterAttribute(
            Type viewModelInitializerType = null)
        {
            if (viewModelInitializerType != null
                && !typeof(IViewModelInitializer).IsAssignableFrom(viewModelInitializerType))
            {
                throw new InvalidViewModelInitializerTypeException(viewModelInitializerType);
            }

            _viewModelInitializerType = viewModelInitializerType;
        }

        public override Task OnActionWithInvalidModelStateExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var modelMetadataProvider =
                (IModelMetadataProvider)context.HttpContext.RequestServices.GetService(typeof(IModelMetadataProvider));
            var viewModel = context.ActionArguments.First().Value;

            if (_viewModelInitializerType != null)
            {
                var viewModelInitializer =
                    (IViewModelInitializer)context.HttpContext.RequestServices.GetService(_viewModelInitializerType);
                viewModel = viewModelInitializer.Initialize(viewModel);
            }

            context.Result = new ViewResult
            {
                ViewName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName,
                ViewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState)
                {
                    Model = viewModel
                }
            };

            return Task.CompletedTask;
        }
    }
}