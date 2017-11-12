using HandleInvalidModelState.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace HandleInvalidModelState.ActionFilters
{
    public class DefaultJsonResultFormatter : IJsonResultFormatter
    {
        public JsonResult Format(object viewModel, ModelStateDictionary modelState)
            => Format(modelState.Errors());

        public virtual JsonResult Format(IEnumerable<string> errors)
            => new JsonResult(new { success = false, errors = errors });
    }
}