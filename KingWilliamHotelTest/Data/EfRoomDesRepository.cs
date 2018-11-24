using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public class EfRoomDesRepository : IRoomDesRepository
    {
        private ApplicationDbContext _ctx;

        public EfRoomDesRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public IQueryable<RoomDes> RoomDess => _ctx.RoomDess;

    }
}
