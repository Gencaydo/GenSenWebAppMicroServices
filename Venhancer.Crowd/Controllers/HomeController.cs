using Microsoft.AspNetCore.Mvc;

namespace Venhancer.Crowd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var UserLoggedIn = HttpContext.Session.GetString("UserLoggedIn");
            var UserSmsVerified = HttpContext.Session.GetString("UserSmsVerified");
            var UserMailVerified = HttpContext.Session.GetString("UserMailVerified");

            if (!string.IsNullOrEmpty(UserLoggedIn) && !string.IsNullOrEmpty(UserSmsVerified) && !string.IsNullOrEmpty(UserMailVerified))
            {
                if(UserLoggedIn == "true" && UserSmsVerified == "true" && UserSmsVerified == "true") return View();
                else return  Redirect("~/Login");
            }
            else return Redirect("~/Login");
        }
    }
}
