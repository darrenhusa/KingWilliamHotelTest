using System;
using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET: /<controller>/
        public ViewResult GetAvailableRooms(int customerId, DateTime startDate, DateTime endDate, string category)
        {
            // .Select(r => new { r.RoomId, r.StartDate, r.EndDate })
            var reservations = _repo.Reservations
                .Where(r => (r.StartDate <= startDate) && (r.EndDate >= endDate))
                .Where(r => ((r.StartDate >= startDate) && (r.StartDate <= endDate)) && (r.EndDate >= endDate))
                .Where(r => (r.StartDate <= startDate) && ((r.EndDate >= startDate) && (r.EndDate <= endDate)));

            ViewBag.Reservations = reservations;

            return View("ListAvailable");
            //return View("ListAvailable", reservations);
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
                TempData["message"] = $"Reservation {reservation.ReservationId} has been saved.";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data vales
                return View(reservation);

            }
           
        }

        // GET: /<controller>/Create
        public ViewResult Create() => View("Edit", new Reservation());

        [HttpPost]
        public IActionResult Delete(int reservationId)
        {
            Reservation deletedReservation = _repo.DeleteReservation(reservationId);

            if (deletedReservation != null)
            {
                TempData["message"] = $"Reservation {deletedReservation.ReservationId} was deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}
