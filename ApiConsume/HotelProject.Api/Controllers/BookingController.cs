using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]         //Yeni bir veri ekliyoruz.
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);

            return Ok(values);
        }
        [HttpPut("UpdateReservationAdmin")]
        public IActionResult UpdateReservationAdmin(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();

        }
        [HttpPut("UpdateReservationAdmin2")]
        public IActionResult UpdateReservationAdmin2(int id)
        {
            _bookingService.TBookingStatusChangeApproved2(id);
            return Ok();

        }
    }
}
