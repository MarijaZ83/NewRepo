using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public IsActiveEnum  IsActive { get; set; }
        public IsDeletedEnum IsDeleted { get; set; }
        public string Picture { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    }
}
