using Microsoft.AspNetCore.Mvc;

namespace WebDotPainter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}