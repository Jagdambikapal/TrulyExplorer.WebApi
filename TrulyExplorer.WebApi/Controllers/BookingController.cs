using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Services;

namespace TrulyExplorer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult GetAllBookings()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingDTO booking)
        {
            _bookingService.AddBooking(booking);
            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] BookingDTO booking)
        {
            var existingBooking = _bookingService.GetBookingById(id);
            if (existingBooking == null)
                return NotFound();

            _bookingService.UpdateBooking(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var existingBooking = _bookingService.GetBookingById(id);
            if (existingBooking == null)
                return NotFound();

            _bookingService.DeleteBooking(id);
            return NoContent();
        }

    }
}
