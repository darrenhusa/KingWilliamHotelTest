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
    }
}
