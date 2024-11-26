using Microsoft.AspNetCore.Mvc;

namespace BabyCradle.Controllers
{
    public class userController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
