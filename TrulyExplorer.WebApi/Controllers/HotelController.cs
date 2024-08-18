using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Models;
using TrulyExplorer.WebApi.Services;

namespace TrulyExplorer.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IHotelAvailabilityService _availabilityService;

        public HotelController(IHotelService hotelService, IHotelAvailabilityService availabilityService)
        {
            _hotelService = hotelService;
            _availabilityService = availabilityService;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels);
        }
        // Create Hotel
        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest("Hotel is null.");
            }

            _hotelService.AddHotel(hotel);
            return Ok("Hotel created successfully.");
        }

        // Update Hotel
        [HttpPut]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest("Hotel is null.");
            }

            _hotelService.UpdateHotel(hotel);
            return Ok("Hotel updated successfully.");
        }

        // Delete Hotel
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            _hotelService.DeleteHotel(id);
            return Ok("Hotel deleted successfully.");
        }

        // Create Hotel Availability
        [HttpPost("availability")]
        public IActionResult CreateHotelAvailability([FromBody] HotelAvailability availability)
        {
            if (availability == null)
            {
                return BadRequest("Availability is null.");
            }

            _availabilityService.AddHotelAvailability(availability);
            return Ok("Hotel availability created successfully.");
        }

        // Update Hotel Availability
        [HttpPut("availability")]
        public IActionResult UpdateHotelAvailability([FromBody] HotelAvailability availability)
        {
            if (availability == null)
            {
                return BadRequest("Availability is null.");
            }

            _availabilityService.UpdateHotelAvailability(availability);
            return Ok("Hotel availability updated successfully.");
        }

        // Delete Hotel Availability
        [HttpDelete("availability/{id}")]
        public IActionResult DeleteHotelAvailability(int id)
        {
            _availabilityService.DeleteHotelAvailability(id);
            return Ok("Hotel availability deleted successfully.");
        }

        // Search Hotels
        [HttpGet("search")]
        public ActionResult<List<Hotel>> SearchHotels([FromQuery] string location, [FromQuery] DateTime date, [FromQuery] int numberOfAdults)
        {
            var hotels = _hotelService.SearchHotels(location, date, numberOfAdults);
            return Ok(hotels);
        }
    }

}
