using TrulyExplorer.WebApi.HotelDto;

namespace TrulyExplorer.WebApi.Services
{
    public interface IHotelService
    {
        IEnumerable<HotelDTO> GetAllHotels();
        HotelDTO GetHotelById(int id);
        void AddHotel(HotelDTO hotel);
        void UpdateHotel(HotelDTO hotel);
        void DeleteHotel(int id);
    }
}
