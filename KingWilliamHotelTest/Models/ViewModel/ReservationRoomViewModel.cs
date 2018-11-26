using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models.ViewModel
{
    public class ReservationRoomViewModel
    {
        //public IEnumerable<Room> Rooms;
        //public IEnumerable<Reservation> Reservations;
        public int RoomId { get; set; }
        public bool Unavailable { get; set; }
        public bool NeedsCleaning { get; set; }
        public int RoomId_y { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
