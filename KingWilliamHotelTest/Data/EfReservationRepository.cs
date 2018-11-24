using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
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

        public void SaveReservation(Reservation reservation)
        {
            if (reservation.ReservationId == 0)
            {
                _ctx.Reservations.Add(reservation);
            }
            else
            {
                Reservation dbEntry = _ctx.Reservations
                    .FirstOrDefault(r => r.ReservationId == reservation.ReservationId);

                if (dbEntry != null)
                {
                    dbEntry.CustomerId = reservation.CustomerId;
                    dbEntry.RoomId = reservation.RoomId;
                    dbEntry.StartDate = reservation.StartDate;
                    dbEntry.EndDate = reservation.EndDate;
                    dbEntry.Amount = reservation.Amount;
                }
            }

            _ctx.SaveChanges();
        }

        public Reservation DeleteReservation(int reservationId)
        {
            Reservation dbEntry = _ctx.Reservations
                .FirstOrDefault(r => r.ReservationId == reservationId);

            if (dbEntry != null)
            {
                _ctx.Reservations.Remove(dbEntry);
                _ctx.SaveChanges();
            }

            return dbEntry;
        }
    }
}
