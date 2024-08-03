using TrulyExplorer.WebApi.Models;

namespace TrulyExplorer.WebApi.Repository
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll(); // Retrieves all bookings
        Booking GetById(int id);       // Retrieves a booking by its ID
        void Add(Booking booking);     // Adds a new booking
        void Update(Booking booking);  // Updates an existing booking
        void Delete(int id);
    }
}
