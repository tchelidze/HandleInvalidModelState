using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HandleInvalidModelState.ActionFilters
{
    public interface IJsonResultFormatter
    {
        JsonResult Format(object viewModel, ModelStateDictionary modelState);
    }
}