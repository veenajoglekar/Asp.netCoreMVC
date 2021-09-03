using EmployeeManagementSys.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.ViewModel
{
    public class EmpFamilyDetailsViewModel
    {
        public Employee Employee { get; set; }
        public EmployeeFamilyDetails EmployeeFamilyDetails { get; set; }
    }
}
