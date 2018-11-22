using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepository _repo;

        public RoomController(IRoomRepository repository)
        {
            _repo = repository;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_repo.Rooms);
        }

        // GET: /<controller>/Edit/id
        //public ViewResult Edit(int reservationId)
        //{
        //    return View(_repo.Reservations
        //        .FirstOrDefault(r => r.ReservationId == reservationId));
        //}

        //[HttpPost]
        //public IActionResult Edit(Reservation reservation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repo.SaveReservation(reservation);
        //        TempData["message"] = $"Reservation {reservation.ReservationId} has been saved.";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data vales
        //        return View(reservation);

        //    }
           
        //}

        //// GET: /<controller>/Create
        //public ViewResult Create() => View("Edit", new Reservation());

        //[HttpPost]
        //public IActionResult Delete(int reservationId)
        //{
        //    Reservation deletedReservation = _repo.DeleteReservation(reservationId);

        //    if (deletedReservation != null)
        //    {
        //        TempData["message"] = $"Reservation {deletedReservation.ReservationId} was deleted.";
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}
