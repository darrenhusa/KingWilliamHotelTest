using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class Reservation
    {
        // Use ReservationId instead of ReservationNo so that EF Core works
        public int ReservationId { get; set; }
        //public int RoomNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Amount { get; set; }

        // FKs
        public int CustomerId { get; set; }
        public int RoomId { get; set; }

        // Navigation properties
        public Room Room { get; set; }
        public Customer Customer { get; set; }
    }
}
