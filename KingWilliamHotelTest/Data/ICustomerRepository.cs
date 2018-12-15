using System.Linq;
using KingWilliamHotelTest.Models;

namespace KingWilliamHotelTest.Data
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        //void SaveCustomer(Customer customer);

        //Room DeleteCustomer(int customerId);
    }
}
