using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SEDCWebApplication.ViewModels
{
    public class CustomerCreateViewModel
    {
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Name { get; set; }
        public string Email { get; set; }
        public IFormFile Picture { get; set; }
        public string ImagePath { get; set; }
    }
}
