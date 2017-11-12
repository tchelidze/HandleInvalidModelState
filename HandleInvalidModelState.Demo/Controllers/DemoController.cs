using HandleInvalidModelState.ActionFilters;
using HandleInvalidModelState.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandleInvalidModelState.Demo.Controllers
{
    public class DemoController : Controller
    {
        private readonly ComplexViewModelInitializer _complexViewModelInitializer;

        public DemoController(
            ComplexViewModelInitializer complexViewModelInitializer)
            => _complexViewModelInitializer = complexViewModelInitializer;

        public IActionResult ViewCaseOne()
            => View(new SimpleViewModel());

        [HttpPost]
        [TypeFilter(typeof(HandleInvalidModelWithViewActionFilterAttribute))]
        public IActionResult ViewCaseOne(SimpleViewModel model)
            => View();

        public IActionResult ViewCaseTwo()
            => View(_complexViewModelInitializer.Initialize(new ComplexViewModel()));

        [HttpPost]
        [TypeFilter(typeof(HandleInvalidModelWithViewActionFilterAttribute),
            Arguments = new object[]
            {
                typeof(ComplexViewModelInitializer)
            })]
        public IActionResult ViewCaseTwo(ComplexViewModel model)
            => View();

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