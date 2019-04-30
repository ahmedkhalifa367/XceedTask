using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XceedTaskEMEMP.Models.ViewModel
{
    public class EmployeeViewModel
    {

        public IEnumerable<Country> Countries { get; set; }
        public Employee Employee { get; set; }
    }
}