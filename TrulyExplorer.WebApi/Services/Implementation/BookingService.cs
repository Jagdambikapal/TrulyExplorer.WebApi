using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Models;
using TrulyExplorer.WebApi.Repository;

namespace TrulyExplorer.WebApi.Services.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<BookingDTO> GetAllBookings()
        {
            return _bookingRepository.GetAll().Select(b => new BookingDTO
            {
                Id = b.Id,
                CustomerId = b.CustomerId,
                RoomId = b.RoomId,
                StartDate = b.StartDate,
                EndDate = b.EndDate
            });
        }

        public BookingDTO GetBookingById(int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
                return null;

            return new BookingDTO
            {
                Id = booking.Id,
                CustomerId = booking.CustomerId,
                RoomId = booking.RoomId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };
        }

        public void AddBooking(BookingDTO booking)
        {
            var newBooking = new Booking
            {
                CustomerId = booking.CustomerId,
                RoomId = booking.RoomId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate
            };
            _bookingRepository.Add(newBooking);
        }

        public void UpdateBooking(BookingDTO booking)
        {
            var existingBooking = _bookingRepository.GetById(booking.Id);
            if (existingBooking != null)
            {
                existingBooking.CustomerId = booking.CustomerId;
                existingBooking.RoomId = booking.RoomId;
                existingBooking.StartDate = booking.StartDate;
                existingBooking.EndDate = booking.EndDate;
                _bookingRepository.Update(existingBooking);
            }
        }

        public void DeleteBooking(int id) => _bookingRepository.Delete(id);
    }

    // Implement CustomerService and RoomService similarly
}

