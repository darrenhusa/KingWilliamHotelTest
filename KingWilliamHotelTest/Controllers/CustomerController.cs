using System;
using System.Linq;
using KingWilliamHotelTest.Data;
using Microsoft.AspNetCore.Mvc;

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
        public ViewResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var customers = from c in _repo.Customers
                select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.LastName.Contains(searchString)
                                               || c.FirstName.Contains(searchString));
            }

            return View(customers);
        }
       
    }
}
