namespace TrulyExplorer.WebApi.Services.Implementation
{
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using TrulyExplorer.WebApi.Models;

    public class HotelAvailabilityService : IHotelAvailabilityService
    {
        private readonly string _connectionString;

        public HotelAvailabilityService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddHotelAvailability(HotelAvailability availability)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO HotelAvailability (HotelId, DateAvailable, Price, AvailableRooms) VALUES (@HotelId, @DateAvailable, @Price, @AvailableRooms)", connection);

                command.Parameters.AddWithValue("@HotelId", availability.HotelId);
                command.Parameters.AddWithValue("@DateAvailable", availability.DateAvailable);
                command.Parameters.AddWithValue("@Price", availability.Price);
                command.Parameters.AddWithValue("@AvailableRooms", availability.AvailableRooms);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateHotelAvailability(HotelAvailability availability)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE HotelAvailability SET DateAvailable = @DateAvailable, Price = @Price, AvailableRooms = @AvailableRooms WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", availability.Id);
                command.Parameters.AddWithValue("@DateAvailable", availability.DateAvailable);
                command.Parameters.AddWithValue("@Price", availability.Price);
                command.Parameters.AddWithValue("@AvailableRooms", availability.AvailableRooms);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteHotelAvailability(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM HotelAvailability WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }

}
