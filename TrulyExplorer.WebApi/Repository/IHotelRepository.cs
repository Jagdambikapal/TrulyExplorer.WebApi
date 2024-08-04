using TrulyExplorer.WebApi.Models;

namespace TrulyExplorer.WebApi.Repository
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();
        Hotel GetById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int id);
    }
}
