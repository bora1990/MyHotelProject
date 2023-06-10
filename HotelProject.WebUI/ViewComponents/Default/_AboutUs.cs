using HotelProject.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUs : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUs(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5251/api/About");

            if (responseMessage.IsSuccessStatusCode)
            {
                //gelen verileri okuduk
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Json verilerini Deserilize ederek List<StaffViewModel e dönüştürmek için normal object formatına çevirdik.
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
