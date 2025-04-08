using Microsoft.AspNetCore.Mvc;

namespace Webapplication.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
