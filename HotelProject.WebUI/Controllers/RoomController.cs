using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoomController : Controller
    {  //consume işlemini viewcomponentte yapmaya karar verdik.
        public IActionResult Index()
        {
            return View();
        }
    }
}
