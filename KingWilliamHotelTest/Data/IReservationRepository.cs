using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> Reservations { get; }

        void SaveReservation(Reservation reservation);

        Reservation DeleteReservation(int reservationId);
    }
}
