using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class Reservation
    {
        //[Key]
        public int ReservationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public double Amount { get; set; }

        // FKs
        //[ForeignKey("CustomerId")]
        //public int CustomerNo { get; set; }
        //[ForeignKey("RoomId")]
        //public int RoomNo { get; set; }

        public int CustomerId { get; set; }
        public int RoomId { get; set; }

        // Navigation properties
        public Room Room { get; set; }
        public Customer Customer { get; set; }
    }
}
