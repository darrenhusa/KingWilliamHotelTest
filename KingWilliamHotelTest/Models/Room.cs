﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class Room
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int RoomNo { get; set; }
        public bool Unavailable { get; set; }
        public bool NeedsCleaning { get; set; }

        // FK
        public string Category { get; set; }

        // Navigation properties
        public ICollection<Reservation> Reservations { get; set; }
        public RoomDes RoomDes { get; set; }

    }
}
