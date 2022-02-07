using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Picture { get; set; }
    }
}
