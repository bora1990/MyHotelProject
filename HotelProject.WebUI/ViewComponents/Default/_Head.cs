using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _Head : ViewComponent
    {
        public IViewComponentResult Invoke() //tasarlanan viewcomponent çağırılıp render edildiğinde içerisinde çalışmasını istediğimiz kodları bu imzada metodun içine yerleştirmeliyiz.Async de olabilir.
        {


            return View(); //burada üretilen data bunun cshtmline gönderilir.2. yolda
            //Default dışında farklı dosya ismi vermek istiyorsak ahmet.cshtml view("ahmet")
        }
    }
}
