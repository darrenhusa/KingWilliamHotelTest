using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class RoomDes
    {
        // Add attribute to set name of PK since breaks the EF Core default rules!
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Category { get; set; }
        public string CategoryDesc { get; set; }
        public double Rate { get; set; }

        // Navigation properties
        public ICollection<Room> Rooms { get; set; }

    }
}
