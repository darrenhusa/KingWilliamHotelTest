﻿using System.Linq;

namespace KingWilliamHotelTest.Models
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> Reservations { get; }
    }
}