using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XceedTaskEMEMP.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        [Display(Name = "Employee Country")]
        public string CountryName { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}