using Microsoft.AspNetCore.Mvc;

namespace ThunderWings.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
