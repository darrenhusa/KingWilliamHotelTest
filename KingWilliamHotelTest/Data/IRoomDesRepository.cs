using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public interface IRoomDesRepository
    {
        IQueryable<RoomDes> RoomDess { get; }

    }
}
