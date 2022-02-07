using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SEDCWebApplication.Models;

namespace SEDCWebApplication.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv pizze")]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public IsActiveEnum IsActive { get; set; }
        public IsDeletedEnum IsDeleted { get; set; }
        public bool IsDiscounted { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        
        
    }
}
