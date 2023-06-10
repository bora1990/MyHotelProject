using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //İstemci (client), bir ağ üzerindeki hizmetlere veya kaynaklara erişmek için bir istekte bulunan veya bir isteği başlatan bir bilgisayar veya yazılım bileşenidir. İstemci, sunucuya (server) bir istek gönderir ve sunucudan gelen yanıtı alır.Burada bir istemci oluşturduk.

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5251/api/Staff");

            if (responseMessage.IsSuccessStatusCode)
            {
                //gelen verileri okuduk
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Json verilerini Deserilize ederek List<StaffViewModel e dönüştürmek için normal object formatına çevirdik.
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            //data gelicek bunu jsona çeviricez.

            var jsonData = JsonConvert.SerializeObject(model);
            //İçerik, data şekli ve türü belirtilir.

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");


            var responseMessage = await client.PostAsync("http://localhost:5251/api/Staff", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5251/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5251/api/Staff/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(model);//jsona çevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "Application/Json");
            //API lere veri yollanırken Json tipi kullanılır.

            var responseMessage = await client.PutAsync("http://localhost:5251/api/Staff/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }


    }
}
