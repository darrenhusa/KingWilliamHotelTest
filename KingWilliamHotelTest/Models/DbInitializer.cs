using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Models
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return; // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer { FirstName = "Darren", LastName = "Henderson" },
                new Customer { FirstName = "Richard", LastName = "Dawson" },
                new Customer { FirstName = "George", LastName = "Foreman" },
                new Customer { FirstName = "Jennifer", LastName = "Lopez" },
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }

            var roomdes = new RoomDes[]
            {
                new RoomDes { Category = "Economy", CategoryDesc = "Economy desc here.", Rate = 50.00},
                new RoomDes { Category = "Deluxe", CategoryDesc = "Deluxe desc here.", Rate = 75.00},
                new RoomDes { Category = "Suite", CategoryDesc = "Suite desc here.", Rate = 100.00}
            };
            foreach (RoomDes rd in roomdes)
            {
                context.RoomDess.Add(rd);
            }

            context.SaveChanges();

            var rooms = new Room[]
            {
                new Room { RoomId = 100, Unavailable = false, NeedsCleaning = false, Category = "Economy"},
                new Room { RoomId = 101, Unavailable = false, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 102, Unavailable = false, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 103, Unavailable = false, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 104, Unavailable = false, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 105, Unavailable = false, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 106, Unavailable = true, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 107, Unavailable = true, NeedsCleaning = false, Category = "Economy" },
                new Room { RoomId = 108, Unavailable = true, NeedsCleaning = true, Category = "Economy" },
                new Room { RoomId = 109, Unavailable = true, NeedsCleaning = true, Category = "Economy" },
            };
            foreach (var r in rooms)
            {
                context.Rooms.Add(r);
            }

            context.SaveChanges();

        }
    }

}