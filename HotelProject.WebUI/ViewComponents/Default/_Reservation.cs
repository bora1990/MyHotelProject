using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _Reservation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
