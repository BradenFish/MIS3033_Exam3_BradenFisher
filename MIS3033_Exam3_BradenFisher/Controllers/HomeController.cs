using Microsoft.AspNetCore.Mvc;

namespace MIS3033_Exam3_BradenFisher.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
