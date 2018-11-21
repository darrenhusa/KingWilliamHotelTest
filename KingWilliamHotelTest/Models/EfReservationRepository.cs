using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Models
{
    public class EfReservationRepository : IReservationRepository
    {
        private ApplicationDbContext _ctx;

        public EfReservationRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public IQueryable<Reservation> Reservations => _ctx.Reservations
            .Include(c => c.Customer)
            .Include(r => r.Room);
    }
}
