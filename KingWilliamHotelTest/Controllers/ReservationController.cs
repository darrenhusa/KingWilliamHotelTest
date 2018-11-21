using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository _repo;

        public ReservationController(IReservationRepository repository)
        {
            _repo = repository;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_repo.Reservations);
        }

        // GET: /<controller>/Edit/id
        public ViewResult Edit(int reservationId)
        {
            return View(_repo.Reservations
                .FirstOrDefault(r => r.ReservationId == reservationId));
        }

        [HttpPost]
        public IActionResult Edit(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveReservation(reservation);
                TempData["message"] = $"{reservation.ReservationId} has been saved.";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data vales
                return View(reservation);

            }
            return View(_repo.Reservations
                .FirstOrDefault(r => r.ReservationId == reservationId));
        }



    }
}
