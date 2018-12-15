using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;
using KingWilliamHotelTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KingWilliamHotelTest.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repository)
        {
            _repo = repository;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(_repo.Customers);
        }
       
    }
}
