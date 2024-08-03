using TrulyExplorer.WebApi.HotelDto;

namespace TrulyExplorer.WebApi.Services
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAllRooms();
        RoomDTO GetRoomById(int id);
        void AddRoom(RoomDTO room);
        void UpdateRoom(RoomDTO room);
        void DeleteRoom(int id);
    }
}
