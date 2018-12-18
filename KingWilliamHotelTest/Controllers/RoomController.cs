using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepository _repo;
        //private IRoomDescRepository _repo;

        public RoomController(IRoomRepository repository)
        {
            _repo = repository;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_repo.Rooms);
        }

        // GET: /<controller>/
        [HttpGet]
        public JsonResult CheckRoomAvailability(int room)
        {
            bool roomAvailability = false;

            var currentRoom = _repo.Rooms
                                        .Where(r => r.RoomId == room)
                                        .Select(r => new {r.NeedsCleaning, r.Unavailable })
                .FirstOrDefault();

            if (currentRoom != null)
            {
                roomAvailability = (!currentRoom.NeedsCleaning && !currentRoom.Unavailable);
            }

            return Json(roomAvailability);
        }

        // GET: /<controller>/
        //public ViewResult GetRoomCategories()
        //{
        //    ViewBag.Categories = new SelectList(_repo.Rooms)
        //    return View();
        //}


        // GET: /<controller>/
        public ViewResult ListAvailable(string category)
        {
            var rooms = _repo.Rooms
                .Where(r => r.Category == category)
                .Where(r => !r.Unavailable)
                .Where(r => !r.NeedsCleaning);

            return View(rooms);
        }
        // GET: /<controller>/Edit/id
        public ViewResult Edit(int roomId)
        {
            return View(_repo.Rooms
                .FirstOrDefault(r => r.RoomId == roomId));
        }

        // POST: /<controller>/Edit/id
        [HttpPost]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveRoom(room);
                TempData["message"] = $"Room {room.RoomId} has been saved.";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data vales
                return View(room);
            }
        }

        // GET: /<controller>/Create
        public ViewResult Create() => View("Edit", new Room());

        // POST: /<controller>/Delete/id
        [HttpPost]
        public IActionResult Delete(int roomId)
        {
            Room deletedRoom = _repo.DeleteRoom(roomId);

            if (deletedRoom != null)
            {
                TempData["message"] = $"Room {deletedRoom.RoomId} was deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}
