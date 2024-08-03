using TrulyExplorer.WebApi.HotelDto;

namespace TrulyExplorer.WebApi.Services
{
    public interface IBookingService
    {
        IEnumerable<BookingDTO> GetAllBookings();
        BookingDTO GetBookingById(int id);
        void AddBooking(BookingDTO booking);
        void UpdateBooking(BookingDTO booking);
        void DeleteBooking(int id);
    }
}
