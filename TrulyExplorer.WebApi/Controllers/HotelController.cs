using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Services;

namespace TrulyExplorer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost]
        public IActionResult AddHotel([FromBody] HotelDTO hotel)
        {
            _hotelService.AddHotel(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = hotel.Id }, hotel);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateHotel(int id, [FromBody] HotelDTO hotel)
        //{
        //    var existingHotel = _hotelService.GetHotelById(id);
        //    if (existingHotel == null)
        //        return NotFound();

        //    _hotelService.UpdateHotel(hotel);
        //    return No
    }
}
