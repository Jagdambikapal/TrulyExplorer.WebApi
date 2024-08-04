using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Models;
using TrulyExplorer.WebApi.Repository;

namespace TrulyExplorer.WebApi.Services.Implementation
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IEnumerable<HotelDTO> GetAllHotels()
        {
            return _hotelRepository.GetAll().Select(h => new HotelDTO
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                Image = h.Image,
                Features = h.Features
            });
        }

        public HotelDTO GetHotelById(int id)
        {
            var hotel = _hotelRepository.GetById(id);
            if (hotel == null)
                return null;

            return new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                Image = hotel.Image,
                Features = hotel.Features
            };
        }

        public void AddHotel(HotelDTO hotel)
        {
            var newHotel = new Hotel
            {
                Name = hotel.Name,
                Description = hotel.Description,
                Image = hotel.Image,
                Features = hotel.Features
            };
            _hotelRepository.Add(newHotel);
        }

        public void UpdateHotel(HotelDTO hotel)
        {
            var existingHotel = _hotelRepository.GetById(hotel.Id);
            if (existingHotel != null)
            {
                existingHotel.Name = hotel.Name;
                existingHotel.Description = hotel.Description;
                existingHotel.Image = hotel.Image;
                existingHotel.Features = hotel.Features;
                _hotelRepository.Update(existingHotel);
            }
        }

        public void DeleteHotel(int id) => _hotelRepository.Delete(id);
    }
}
