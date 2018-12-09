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
                new Customer { CustomerId = 110, FirstName = "Richard", LastName = "Dawson" },
                new Customer { CustomerId = 120, FirstName = "George", LastName = "Foreman" },
                new Customer { CustomerId = 125, FirstName = "Jennifer", LastName = "Lopez" },
                new Customer { CustomerId = 130, FirstName = "Matt", LastName = "Nagy" },
                new Customer { CustomerId = 140, FirstName = "Mitch", LastName = "Trubisky" },
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
                new Room { RoomId = 106, Unavailable = true, NeedsCleaning = true, Category = "Economy" },
                new Room { RoomId = 107, Unavailable = true, NeedsCleaning = true, Category = "Economy" },
                new Room { RoomId = 108, Unavailable = false, NeedsCleaning = true, Category = "Economy" },
                new Room { RoomId = 109, Unavailable = false, NeedsCleaning = true, Category = "Economy" },
                new Room { RoomId = 200, Unavailable = false, NeedsCleaning = true, Category = "Deluxe" },
                new Room { RoomId = 201, Unavailable = true, NeedsCleaning = true, Category = "Deluxe" },
                new Room { RoomId = 300, Unavailable = true, NeedsCleaning = false, Category = "Suite" },
                new Room { RoomId = 301, Unavailable = false, NeedsCleaning = false, Category = "Suite" },
                new Room { RoomId = 302, Unavailable = true, NeedsCleaning = false, Category = "Suite" },
            };
            foreach (var r in rooms)
            {
                context.Rooms.Add(r);
            }

            context.SaveChanges();

            var reservations = new Reservation[]
            {
                new Reservation {RoomId = 100, 
                                 StartDate = new DateTime(2018, 11, 25),
                                 EndDate = new DateTime(2018, 11, 30),
                                 Amount = 0.0,
                                 CustomerId = 100},
                
                new Reservation {RoomId = 101, 
                                 StartDate = new DateTime(2018, 11, 25),
                                 EndDate = new DateTime(2018, 11, 27),
                                 Amount = 0.0,
                                 CustomerId = 110},

                new Reservation {RoomId = 300,
                                 StartDate = new DateTime(2018, 11, 23),
                                 EndDate = new DateTime(2018, 11, 30),
                                 Amount = 0.0,
                                 CustomerId = 130},

                new Reservation {RoomId = 105,
                                 StartDate = new DateTime(2018, 11, 23),
                                 EndDate = new DateTime(2018, 11, 30),
                                 Amount = 0.0,
                                 CustomerId = 120},

                new Reservation {RoomId = 100,
                                 StartDate = new DateTime(2018, 12, 1),
                                 EndDate = new DateTime(2018, 12, 5),
                                 Amount = 0.0,
                                 CustomerId = 120},

                new Reservation {RoomId = 201,
                                 StartDate = new DateTime(2018, 11, 25),
                                 EndDate = new DateTime(2018, 11, 30),
                                 Amount = 0.0,
                                 CustomerId = 140},

            };

            foreach (var r in reservations)
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();

        }
    }

}