using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEdit()
        {
            return View();
        }
    }
}
