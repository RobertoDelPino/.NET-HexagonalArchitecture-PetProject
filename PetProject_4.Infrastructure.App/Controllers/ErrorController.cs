using Microsoft.AspNetCore.Mvc;

namespace PetProject_3.Controllers
{
    [Route("ErrorPage/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            ViewData["Error"] = statusCode switch
                                {
                                    404 => "Page Not Found",
                                    _ => "Error",
                                };

            return View("ErrorPage");
        }
    }
}
