using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models.Interfaces;

namespace SEDCWebApplication.Models.Implementations
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="Pera",
                    Company="Seavus",
                    Email= "pera@pera.com",
                    
                    Picture="~/images/Employees/pera.png"
                },
                new Employee
                {
                    Id=2,
                    Name="Mika",
                    Company="Seavus",
                    Email="mika@mika.com",
                    Picture="~/images/Employees/mika.jpg"
                },
                new Employee
                {
                    Id=3,
                    Name="Laza",
                    Company="Seavus",
                    Email="laza@laza.com",
                    Picture="~/images/Employees/laza.jpg"
                }
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
    }
}
