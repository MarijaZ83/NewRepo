using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.Interfaces;

namespace SEDCWebApplication.Models.Implementations
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList;

        public MockCustomerRepository()
        {
            _customerList = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Sanja",
                    Email = "sanja@sanja.com",
                    Picture = "~/images/Customer/sanja.jpg"
                },
                new Customer
                {
                   Id = 2,
                   Name = "Tanja",
                   Email = "tanja@tanja.com",
                   Picture = "~/images/Customer/tanja.jpg"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Vanja",
                    Email = "vanja@tanja.com",
                   Picture = "~/images/Customer/vanja.jpg"
                }
            };

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }

        public Customer Add(Customer customer)
        {
            customer.Id = _customerList.Max(c => c.Id) + 1;
            _customerList.Add(customer);
            return customer;
        }
    }
}
