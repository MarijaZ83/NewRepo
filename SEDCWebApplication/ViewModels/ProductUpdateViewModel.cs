using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SEDCWebApplication.Models;

namespace SEDCWebApplication.ViewModels
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public IsActiveEnum IsActive { get; set; }
        public IsDeletedEnum IsDeleted { get; set; }
        public IFormFile Picture { get; set; }
        public string ImagePath { get; set; }
    }
}
