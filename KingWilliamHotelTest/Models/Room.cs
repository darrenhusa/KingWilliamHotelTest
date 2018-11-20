using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class Room
    {
        // Use RoomId instead of RoomNo so that EF Core works
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }
        public bool Unavailable { get; set; }
        public bool NeedsCleaning { get; set; }

        // FK
        public string Category { get; set; }

        // Navigation properties
        public ICollection<RoomDes> RoomDess { get; set; }
    }
}
