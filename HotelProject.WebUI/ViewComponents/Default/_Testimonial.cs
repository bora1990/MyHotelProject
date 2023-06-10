using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _Testimonial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5251/api/Testimonial");

            if (responseMessage.IsSuccessStatusCode)
            {
                //gelen verileri okuduk
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Json verilerini Deserilize ederek List<StaffViewModel e dönüştürmek için normal object formatına çevirdik.
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
