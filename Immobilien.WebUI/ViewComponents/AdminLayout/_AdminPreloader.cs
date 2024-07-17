using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.AdminLayout
{
    public class _AdminPreloader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
