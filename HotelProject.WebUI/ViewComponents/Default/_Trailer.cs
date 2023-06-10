using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _Trailer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
