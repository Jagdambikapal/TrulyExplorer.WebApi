using TrulyExplorer.WebApi.Models;

public interface IHotelAvailabilityService
{
    void AddHotelAvailability(HotelAvailability availability);
    void UpdateHotelAvailability(HotelAvailability availability);
    void DeleteHotelAvailability(int id);
}
