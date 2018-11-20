using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class RoomDes
    {
        // Add attribute to set name of PK since breaks the EF Core default rules!
        public string Category { get; set; }
        public string CategoryDesc { get; set; }
        public decimal Rate { get; set; }
    }
}
