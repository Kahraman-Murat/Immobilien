using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.AdminLayout
{
    public class _AdminFooter: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
