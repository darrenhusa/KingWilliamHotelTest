using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public class EfCustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _ctx;

        public EfCustomerRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public IQueryable<Customer> Customers => _ctx.Customers;

        //public void SaveRoom(Room room)
        //{
        //    if (room.RoomId == 0)
        //    {
        //        _ctx.Rooms.Add(room);
        //    }
        //    else
        //    {
        //        Room dbEntry = _ctx.Rooms
        //            .FirstOrDefault(r => r.RoomId == room.RoomId);

        //        if (dbEntry != null)
        //        {
        //            dbEntry.RoomId = room.RoomId;
        //            dbEntry.Category = room.Category;
        //            dbEntry.NeedsCleaning = room.NeedsCleaning;
        //            dbEntry.Unavailable = room.Unavailable;
        //        }
        //    }

        //    _ctx.SaveChanges();
        //}

        //public Room DeleteRoom(int roomId)
        //{
        //    Room dbEntry = _ctx.Rooms
        //        .FirstOrDefault(r => r.RoomId == roomId);

        //    if (dbEntry != null)
        //    {
        //        _ctx.Rooms.Remove(dbEntry);
        //        _ctx.SaveChanges();
        //    }

        //    return dbEntry;
        //}
    }
}
