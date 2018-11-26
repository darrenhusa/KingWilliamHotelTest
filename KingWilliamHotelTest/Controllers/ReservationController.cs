using System;
using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using KingWilliamHotelTest.Models.ViewModel;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationRepository _repo;
        private IRoomRepository _roomRepo;

        public ReservationController(IReservationRepository repository, IRoomRepository roomRepository)
        {
            _repo = repository;
            _roomRepo = roomRepository;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_repo.Reservations);
        }

        // GET: /<controller>/
        public ViewResult GetValues()
        {
            return View();
        }

        // GET: /<controller>/
        public ViewResult GetAvailableRooms(int customerId, DateTime startDate, DateTime endDate, string category)
        {
            ReservationRoomViewModel data = new  ReservationRoomViewModel();

            // .Select(r => new { r.RoomId, r.StartDate, r.EndDate })
            var reservations = _repo.Reservations
                .Select(r => new { r.RoomId, r.StartDate, r.EndDate })
                .Where(r => (r.StartDate <= startDate) && (r.EndDate >= endDate))
                .Where(r => ((r.StartDate >= startDate) && (r.StartDate <= endDate)) && (r.EndDate >= endDate))
                .Where(r => (r.StartDate <= startDate) && ((r.EndDate >= startDate) && (r.EndDate <= endDate)));

            var rooms = _roomRepo.Rooms.Where(r => r.Category == category);

            // outer join query using linq method syntax
            var query = rooms.GroupJoin(reservations,
                room => room.RoomId,
                reservation => reservation.RoomId,
                (room, reservationGroup) => new
                {
                    RoomId = room.RoomId,
                    Unavailable = room.Unavailable,
                    NeedsCleaning = room.NeedsCleaning,
                    Reservations = reservationGroup
                });

            //data.Reservations = reservations;
            //data.Rooms = availableRooms;

            return View("ListAvailable", query);
            //return View("ListAvailable", data);
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
