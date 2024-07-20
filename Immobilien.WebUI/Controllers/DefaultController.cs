using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
