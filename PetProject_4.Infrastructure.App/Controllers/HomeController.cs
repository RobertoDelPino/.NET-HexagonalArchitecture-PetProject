using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PetProject_3.Controllers
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
            var isUserAuthenticated = User?.Identity?.IsAuthenticated;
            return isUserAuthenticated != null && isUserAuthenticated == true 
                    ? Redirect("/UserProjects") 
                    : View();
        }

        public IActionResult Privacy()
        {
            var isUserAuthenticated = User?.Identity?.IsAuthenticated;
            if (isUserAuthenticated != null && isUserAuthenticated == true)
            {
                return Redirect("/UserProjects");
            }
            return View();
        }
    }
}