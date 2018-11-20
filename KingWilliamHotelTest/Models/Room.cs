﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class Room
    {
        // Use RoomId instead of RoomNo so that EF Core works
        public int RoomId { get; set; }
        public bool Unavailable { get; set; }
        public bool NeedsCleaning { get; set; }

        // FKs
        public string Category { get; set; }

    }
}