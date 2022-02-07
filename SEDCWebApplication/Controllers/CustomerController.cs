using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.Implementations;
using SEDCWebApplication.Models.Interfaces;
using SEDCWebApplication.ViewModels;

namespace SEDCWebApplication.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private List<Customer> _customer;

        public CustomerController(ICustomerRepository customerRepository, IHostingEnvironment hostingEnvironment)
        {
            //Bez Dependency Injection-a
            //MockCustomerRepository mockCustomerRepository = new MockCustomerRepository();
            //_customer = mockCustomerRepository.GetAllCustomers().ToList();

            //Sa Dependency Injection-om
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;
            //_customer = _customerRepository.GetAllCustomers().ToList();
        }

        [Route("Index")]
        public IActionResult Index()
        {
            //    ViewBag.Customers = _customer;

            List<Customer> customer = _customerRepository.GetAllCustomers().ToList();
            ViewBag.Title = "Customers";

            return View(customer);
        }

        [Route("Details/{id}")]

        public IActionResult Details (int id)
        {
            //MockCustomerRepository mockCustomerRepository = new MockCustomerRepository();
            //Customer _customer = mockCustomerRepository.GetCustomerById(id);


            Customer _customer = _customerRepository.GetCustomerById(id);

            CustomerDetailsViewModel customerVM = new CustomerDetailsViewModel();
            customerVM.Id = _customer.Id;
            customerVM.Name = _customer.Name;
            customerVM.Picture = _customer.Picture;
            customerVM.Email = _customer.Email;

            return View(customerVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "mini.jpg";

                if (model.Picture != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                    Customer customer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    ImagePath = "~/images/" + uniqueFileName
                };

                Customer newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("Index", new { id = newCustomer.Id });
            }
            else
            {
                return View();
            }
        }

        //Edit
        [HttpGet]
        [Route("Update/{id}")]
        public IActionResult Update(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            CustomerUpdateViewModel customerUpdateViewModel = new CustomerUpdateViewModel
            {
                //Id = product.Id,
                Name = customer.Name,
                Email = customer.Email               
            };
            return View(customerUpdateViewModel);
        }

        [HttpPost]
        [Route("Update/{id}")]

        public IActionResult Update(int id, CustomerUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _customerRepository.GetCustomerById(id);
                customer.Name = model.Name;
                customer.Email = model.Email;

                string uniqueFileName = "mini.jpg";
                if (model.Picture != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                customer.ImagePath = "~/images/" + uniqueFileName;

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
