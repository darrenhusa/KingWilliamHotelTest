using System;
using System.Collections.Generic;
using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _repo;
        private readonly IRoomRepository _roomRepo;
        private readonly IRoomDesRepository _roomDesRepo;

        public ReservationController(IReservationRepository repository, IRoomRepository roomRepository, IRoomDesRepository roomDesRepository)
        {
            _repo = repository;
            _roomRepo = roomRepository;
            _roomDesRepo = roomDesRepository;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_repo.Reservations);
        }

        // GET: /<controller>/
        public ViewResult GetValues()
        {
            var roomTypes = _roomDesRepo.RoomDess
                .Select(r => r.Category);

            // Load room types in ViewBag
            ViewBag.ListOfRoomTypes = roomTypes;

            return View();
        }

        // POST: /<controller>/
        // TO DO - work on code so that clicking SAVE on make reservation writes the record to the database!!!

        [HttpPost]
        public IActionResult GetValues(Reservation reservation)
        {
            //var roomTypes = _roomDesRepo.RoomDess
            //    .Select(r => r.Category);

            //// Load room types in ViewBag
            //ViewBag.ListOfRoomTypes = roomTypes;

            return View();
        }

        // GET: /<controller>/
        [HttpGet]
        public JsonResult GetAvailableRooms(DateTime StartDate, DateTime EndDate, string Category)
        {
            //var startDate = new DateTime(2018, 11, 25);
            //var endDate = new DateTime(2018, 11, 30);
            //var category = "Economy";

            var rot = _roomRepo.Rooms.Where(r => r.Category == Category)
                           .OrderBy(r => r.RoomId);

            var r1 = _repo.Reservations.Where(r => (r.StartDate <= StartDate && r.EndDate >= EndDate) ||
                            (r.StartDate >= StartDate && r.StartDate <= EndDate && r.EndDate >= EndDate) ||
                            (r.StartDate <= StartDate && r.StartDate >= StartDate && r.EndDate <= EndDate));

            //IEnumerable<AvailableRooms> MyData =
            var MyData =
                from room in rot
                join room2 in r1 on room.RoomId equals room2.RoomId into gj
                from sr in gj.DefaultIfEmpty()
                where sr.RoomId == null
                select new AvailableRooms
                {
                    RoomNo = room.RoomId,
                };

            return Json(MyData);
            //return View("ListAvailable", MyData);
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
