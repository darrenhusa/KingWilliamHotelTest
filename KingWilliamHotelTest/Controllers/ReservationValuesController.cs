using System;
using System.Collections.Generic;
using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace KingWilliamHotelTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationValuesController : ControllerBase
    {
        private readonly IReservationRepository _repo;
        private readonly IRoomRepository _roomRepo;

        public ReservationValuesController(IReservationRepository repository, IRoomRepository roomRepository)
        {
            _repo = repository;
            _roomRepo = roomRepository;

        }

        [HttpGet]
        public IEnumerable<AvailableRooms> Get()
        {
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

            return MyData;
        }
    }
}