using TrulyExplorer.WebApi.Models;

namespace TrulyExplorer.WebApi.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings = new List<Booking>();

        public IEnumerable<Booking> GetAll() => _bookings;

        public Booking GetById(int id) => _bookings.FirstOrDefault(b => b.Id == id);

        public void Add(Booking booking) => _bookings.Add(booking);

        public void Update(Booking booking)
        {
            var existingBooking = GetById(booking.Id);
            if (existingBooking != null)
            {
                existingBooking.CustomerId = booking.CustomerId;
                existingBooking.RoomId = booking.RoomId;
                existingBooking.StartDate = booking.StartDate;
                existingBooking.EndDate = booking.EndDate;
            }
        }

        public void Delete(int id) => _bookings.Remove(GetById(id));
    }

   
}
