using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingWilliamHotelTest.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int CustomerNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        //public string MI { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Zip { get; set; }
        //public string Phone { get; set; }
        //public string CreditCardNumber { get; set; }
        //public DateTime CardExpDate { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
