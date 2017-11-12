using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace HandleInvalidModelState.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static bool IsNotValid(this ModelStateDictionary modelStateDictionary) => !modelStateDictionary.IsValid;

        public static IEnumerable<string> Errors(this ModelStateDictionary modelStateDictionary)
            => modelStateDictionary.Values.SelectMany(it => it.Errors).Select(it => it.ErrorMessage);
    }
}