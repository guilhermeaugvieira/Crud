using Microsoft.AspNetCore.Mvc;

namespace Examples.Charge.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
