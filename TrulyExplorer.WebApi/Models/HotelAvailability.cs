namespace TrulyExplorer.WebApi.Models
{
    public class HotelAvailability
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public DateTime DateAvailable { get; set; }
        public decimal Price { get; set; }
        public int AvailableRooms { get; set; }
    }
}
