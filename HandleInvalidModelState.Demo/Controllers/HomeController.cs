using Microsoft.AspNetCore.Mvc;

namespace HandleInvalidModelState.Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}