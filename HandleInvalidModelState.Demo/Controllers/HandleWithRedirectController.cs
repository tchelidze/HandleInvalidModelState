using HandleInvalidModelState.ActionFilters;
using HandleInvalidModelState.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandleInvalidModelState.Demo.Controllers
{
    public class HandleWithRedirectController : Controller
    {
        [TypeFilter(typeof(HandleInvalidModelWithRedirectActionFilterAttribute), Arguments = new object[]
        {
            "/HandleWithRedirect/EntityNotFound"
        })]
        public IActionResult RedirectCaseOne(GetDetailsViewModel model)
            => View();

        public IActionResult EntityNotFound() => View();
    }
}