using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;


        public BookingAdminController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5251/api/Booking");

            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation(ApprovedReservationBookingDto approvedReservationBookingDto, int id, string status)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5251/api/Booking");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
            if (responseMessage.IsSuccessStatusCode)
            {
                var arananData = values.Find(x => x.BookingID == id);
                var formattedData = _mapper.Map<Booking>(arananData);

                formattedData.Status = status;


                var jsonData1 = JsonConvert.SerializeObject(formattedData);
                StringContent stringContent = new StringContent(jsonData1, Encoding.UTF8, "application/json");

                var responseMessage1 = await client.PutAsync("http://localhost:5251/api/Booking/UpdateBooking", stringContent);

                if (responseMessage1.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
            }

            return View();
        }
    }
}
