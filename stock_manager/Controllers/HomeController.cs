using Microsoft.AspNetCore.Mvc;

namespace stock_manager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}