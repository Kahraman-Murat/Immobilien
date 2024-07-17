using Microsoft.AspNetCore.Mvc;

namespace Immobilien.WebUI.ViewComponents.AdminLayout
{
    public class _AdminHeader:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {  
            return View(); 
        }
    }
}
