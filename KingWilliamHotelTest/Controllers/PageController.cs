using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Controllers
{
    public class PageController : Controller
    {
        //private IRoomRepository _repo;
        //private IRoomDescRepository _repo;

        //public RoomController(IRoomRepository repository)
        //{
        //    _repo = repository;
        //}

        // GET: /<controller>/
        public ViewResult AjaxTest() => View();

    }
}
