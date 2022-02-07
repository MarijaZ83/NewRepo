using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication.Models
{
    public enum IsDeletedEnum
    {
        [Display(Name = "Yes")]
        Yes,
        No
    }
}
