using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.AdminLayout
{
    public class _AdminNavHeader: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
