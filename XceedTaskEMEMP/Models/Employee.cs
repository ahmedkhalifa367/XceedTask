using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XceedTaskEMEMP.Models
{
    public class Employee
    {
        [Key]
        public int empID { get; set; }
        [ValidationUtility]
        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(30, MinimumLength = 5)]
        public string empName { get; set; }
        [Display(Name = "Employee Age")]
        [Range(20, 45, ErrorMessage = "Must Be Between 20 : 45")]
        public int? age { get; set; }
        [validationUtilityPhone]
        [Required]
        [Display(Name = "Employee PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Not a valid phone number")]
        public string phoneNumber { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}