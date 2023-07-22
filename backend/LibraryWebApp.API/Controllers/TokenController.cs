using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.API.Controllers
{
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
