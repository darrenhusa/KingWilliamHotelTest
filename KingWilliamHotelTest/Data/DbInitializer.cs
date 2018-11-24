using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingWilliamHotelTest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KingWilliamHotelTest.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return; // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer { CustomerId = 100, FirstName = "Darren", LastName = "Henderson" },
                new Customer { CustomerId = 150, FirstName = "Richard", LastName = "Dawson" },
                new Customer { CustomerId = 200, FirstName = "George", LastName = "Foreman" },
                new Customer { CustomerId = 250, FirstName = "Jennifer", LastName = "Lopez" },
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

            var reservations = new Reservation[]
            {
                new Reservation {RoomId = 100, CustomerId = 100,
                                 StartDate = new DateTime(2018, 11, 22),
                                 EndDate = new DateTime(2018, 11, 25),
                                 Amount = 100.0},
                new Reservation {RoomId = 101, CustomerId = 250,
                                 StartDate = new DateTime(2018, 11, 24),
                                 EndDate = new DateTime(2018, 11, 30),
                                 Amount = 300.0}
            };

            foreach (var r in reservations)
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();

        }
    }

}