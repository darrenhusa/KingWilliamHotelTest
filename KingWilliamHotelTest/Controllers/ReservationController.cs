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
        public ViewResult GetAvailableRooms()
        //public ViewResult GetAvailableRooms(DateTime startDate, DateTime endDate, string category)
        {
            //ReservationRoomViewModel data = new  ReservationRoomViewModel();

            var startDate = new DateTime(2018, 11, 25);
            var endDate = new DateTime(2018, 11, 30);
            var category = "Economy";

            var rot = _roomRepo.Rooms.Where(r => r.Category == category)
                           .OrderBy(r => r.RoomId);

            var r1 = _repo.Reservations.Where(r => (r.StartDate <= startDate && r.EndDate >= endDate) ||
                            (r.StartDate >= startDate && r.StartDate <= endDate && r.EndDate >= endDate) ||
                            (r.StartDate <= startDate && r.StartDate >= startDate && r.EndDate <= endDate));

            var MyData =
                from room in rot
                join room2 in r1 on room.RoomId equals room2.RoomId into gj
                from sr in gj.DefaultIfEmpty()
                where sr.RoomId == null
                select new AvailableRooms
                {
                    RoomNo = room.RoomId,
                };

            return View("ListAvailable", MyData);
        }

        public class AvailableRooms
        {
            public int RoomNo { get; set; }
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
