using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SEDCWebApplication.ViewModels
{
    public class EmployeeUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public IFormFile Picture { get; set; }
        public string ImagePath { get; set; }
    }
}
