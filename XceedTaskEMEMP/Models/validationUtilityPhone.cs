using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XceedTaskEMEMP.Models
{
    public class validationUtilityPhone : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            XceedEmpDB db = new XceedEmpDB();
            var myEmp = (Employee)validationContext.ObjectInstance;
            var Employee = db.Employees.FirstOrDefault(a => a.phoneNumber == myEmp.phoneNumber);
            if (Employee == null)
                return ValidationResult.Success;
            if (Employee.empID == myEmp.empID)
                return ValidationResult.Success;
            return new ValidationResult("This Employee Phone Aleardy Exist");
        }
    }
}