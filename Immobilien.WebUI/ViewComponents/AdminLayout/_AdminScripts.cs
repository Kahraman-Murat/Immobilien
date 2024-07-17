using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.AdminLayout
{
    public class _AdminScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
