using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public interface IRoomRepository
    {
        IQueryable<Room> Rooms { get; }

        void SaveRoom(Room room);

        Room DeleteRoom(int roomId);
    }
}
