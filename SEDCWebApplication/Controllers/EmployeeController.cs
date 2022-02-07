using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SEDCWebApplication.Models;
using SEDCWebApplication.Models.Implementations;
using SEDCWebApplication.Models.Interfaces;
using SEDCWebApplication.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SEDCWebApplication.Controllers
{
    [Route("Employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        //private List<Employee> _employee;

        public EmployeeController(IEmployeeRepository employeeRepository, IHostingEnvironment _hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = _hostingEnvironment;

            //_employee = _employeeRepository.GetAllEmployees().ToList();
        }

        [Route("Index")]
        public IActionResult Index()
        {
            List<Employee> employee = _employeeRepository.GetAllEmployees().ToList();
            ViewBag.Title = "Employees";

            return View(employee);
        }

        [Route("Details/{id}")]

        public IActionResult Details(int id)
        {
            Employee _employee = _employeeRepository.GetEmployeeById(id);

            EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel();
            employeeVM.Id = _employee.Id;
            employeeVM.Name = _employee.Name;
            employeeVM.Picture = _employee.Picture;
            employeeVM.Company = _employee.Company;
            employeeVM.Email = _employee.Email;

            return View(employeeVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(EmployeeCreateViewModel model)
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

                Employee employee = new Employee
                {
                    Name = model.Name,
                    Company = model.Company,
                    Email = model.Email,
                    ImagePath = "~/images/" + uniqueFileName
                };

                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Index", new { id = newEmployee.Id });
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
            Employee employee = _employeeRepository.GetEmployeeById(id);
            EmployeeUpdateViewModel employeeUpdateViewModel = new EmployeeUpdateViewModel
            {
                //Id = product.Id,
                Name = employee.Name,
                Company = employee.Company,
                Email = employee.Email
            };
            return View(employeeUpdateViewModel);
        }

        [HttpPost]
        [Route("Update/{id}")]

        public IActionResult Update(int id, EmployeeUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployeeById(id);
                employee.Name = model.Name;
                employee.Company = model.Company;
                employee.Email = model.Email;

                string uniqueFileName = "mini.jpg";
                if (model.Picture != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                employee.ImagePath = "~/images/" + uniqueFileName;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
