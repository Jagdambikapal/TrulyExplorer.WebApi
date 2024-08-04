using System.Data.SqlClient;
using TrulyExplorer.WebApi.Models;

namespace TrulyExplorer.WebApi.Repository.Implementation
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public HotelRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Hotel> GetAll()
        {
            var hotels = new List<Hotel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Hotels", conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hotels.Add(new Hotel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Image = reader.GetString(3),
                            Features = reader.GetString(4)
                        });
                    }
                }
            }

            return hotels;
        }

        public Hotel GetById(int id)
        {
            Hotel hotel = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Hotels WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hotel = new Hotel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Image = reader.GetString(3),
                            Features = reader.GetString(4)
                        };
                    }
                }
            }

            return hotel;
        }

        public void Add(Hotel hotel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Hotels (Name, Description, Image, Features) VALUES (@Name, @Description, @Image, @Features)",
                    conn);
                cmd.Parameters.AddWithValue("@Name", hotel.Name);
                cmd.Parameters.AddWithValue("@Description", hotel.Description);
                cmd.Parameters.AddWithValue("@Image", hotel.Image);
                cmd.Parameters.AddWithValue("@Features", hotel.Features);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Hotel hotel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Hotels SET Name = @Name, Description = @Description, Image = @Image, Features = @Features WHERE Id = @Id",
                    conn);
                cmd.Parameters.AddWithValue("@Id", hotel.Id);
                cmd.Parameters.AddWithValue("@Name", hotel.Name);
                cmd.Parameters.AddWithValue("@Description", hotel.Description);
                cmd.Parameters.AddWithValue("@Image", hotel.Image);
                cmd.Parameters.AddWithValue("@Features", hotel.Features);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Hotels WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

