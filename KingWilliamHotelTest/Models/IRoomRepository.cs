using System.Linq;

namespace KingWilliamHotelTest.Models
{
    public interface IRoomRepository
    {
        IQueryable<Room> Rooms { get; }

        void SaveRoom(Room room);

        Room DeleteRoom(int roomId);
    }
}
