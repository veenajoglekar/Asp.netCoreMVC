using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.Data.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Salary{ get; set; }

        public string Address{ get; set; }

        public string Role { get; set; }
    }
}
