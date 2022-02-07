using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.Interfaces;

namespace SEDCWebApplication.Models.Implementations
{
    public class DatabaseCustomerRepository : ICustomerRepository
    {

        public IEnumerable<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Add(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
