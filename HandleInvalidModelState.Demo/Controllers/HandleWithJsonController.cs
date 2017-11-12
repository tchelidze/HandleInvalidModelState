using HandleInvalidModelState.ActionFilters;
using HandleInvalidModelState.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandleInvalidModelState.Demo.Controllers
{
    public class HandleWithJsonController : Controller
    {
        public IActionResult JsonCaseOne()
            => View();

        [HttpPost]
        [TypeFilter(typeof(HandleInvalidModelWithJsonActionFilterAttribute))]
        public IActionResult JsonCaseOne(SimpleViewModel model)
            => Json(new { success = true });

        public IActionResult JsonCaseTwo()
            => View();

        [HttpPost]
        [TypeFilter(typeof(HandleInvalidModelWithJsonActionFilterAttribute), Arguments = new object[]
        {
            typeof(CustomJsonResultFormatter)
        })]
        public IActionResult JsonCaseTwo(SimpleViewModel model)
            => Json(new { success = true });
    }
}