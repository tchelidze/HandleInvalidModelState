using HandleInvalidModelState.ActionFilters;
using HandleInvalidModelState.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HandleInvalidModelState.Demo
{
    public class CustomJsonResultFormatter : IJsonResultFormatter
    {
        public JsonResult Format(object viewModel, ModelStateDictionary modelState)
            => new JsonResult(new
            {
                isSuccessful = false,
                errorMessages = modelState.Errors()
            });
    }
}