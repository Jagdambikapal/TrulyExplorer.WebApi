using TrulyExplorer.WebApi.HotelDto;
using TrulyExplorer.WebApi.Models;
using TrulyExplorer.WebApi.Repository;

namespace TrulyExplorer.WebApi.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using TrulyExplorer.WebApi.Repository.Implementation;

    public class HotelService : IHotelService
    {
        private readonly string _connectionString;
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IConfiguration configuration, IHotelRepository hotelRepository)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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


        public async void AddHotel(Hotel hotel)
        {
           
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();
            //    var command = new SqlCommand("INSERT INTO Hotels (Name, Description, Image, Features, Location) VALUES (@Name, @Description, @Image, @Features, @Location)", connection);

            //    command.Parameters.AddWithValue("@Name", hotel.Name);
            //    command.Parameters.AddWithValue("@Description", hotel.Description);
            //    command.Parameters.AddWithValue("@Image", hotel.Image);
            //    command.Parameters.AddWithValue("@Features", hotel.Features);
            //    command.Parameters.AddWithValue("@Location", hotel.Location);

            //    command.ExecuteNonQuery();
            //}
        }

        public void UpdateHotel(Hotel hotel)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Hotels SET Name = @Name, Description = @Description, Image = @Image, Features = @Features, Location = @Location WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Id", hotel.Id);
                command.Parameters.AddWithValue("@Name", hotel.Name);
                command.Parameters.AddWithValue("@Description", hotel.Description);
                command.Parameters.AddWithValue("@Image", hotel.Image);
                command.Parameters.AddWithValue("@Features", hotel.Features);
                command.Parameters.AddWithValue("@Location", hotel.Location);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteHotel(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Hotels WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Hotel> SearchHotels(string location, DateTime date, int numberOfAdults)
        {
            var hotels = new List<Hotel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"
                SELECT h.Id, h.Name, h.Description, h.Image, h.Features, h.Location
                FROM Hotels h
                JOIN HotelAvailability ha ON h.Id = ha.HotelId
                WHERE h.Location LIKE @Location
                AND ha.DateAvailable = @Date
                AND ha.AvailableRooms >= @NumberOfAdults";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Location", "%" + location + "%");
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@NumberOfAdults", numberOfAdults);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var hotel = new Hotel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Image = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Features = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Location = reader.IsDBNull(5) ? null : reader.GetString(5)
                            };

                            hotels.Add(hotel);
                        }
                    }
                }
            }

            return hotels;
        }
    }

}
