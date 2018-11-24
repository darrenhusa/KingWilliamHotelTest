using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public class EfRoomRepository : IRoomRepository
    {
        private ApplicationDbContext _ctx;

        public EfRoomRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public IQueryable<Room> Rooms => _ctx.Rooms;
        //.Include(c => c.Customer)
        //.Include(r => r.Room);

        public void SaveRoom(Room room)
        {
            if (room.RoomId == 0)
            {
                _ctx.Rooms.Add(room);
            }
            else
            {
                Room dbEntry = _ctx.Rooms
                    .FirstOrDefault(r => r.RoomId == room.RoomId);

                if (dbEntry != null)
                {
                    dbEntry.RoomId = room.RoomId;
                    dbEntry.Category = room.Category;
                    dbEntry.NeedsCleaning = room.NeedsCleaning;
                    dbEntry.Unavailable = room.Unavailable;
                }
            }

            _ctx.SaveChanges();
        }

        public Room DeleteRoom(int roomId)
        {
            Room dbEntry = _ctx.Rooms
                .FirstOrDefault(r => r.RoomId == roomId);

            if (dbEntry != null)
            {
                _ctx.Rooms.Remove(dbEntry);
                _ctx.SaveChanges();
            }

            return dbEntry;
        }
    }
}
