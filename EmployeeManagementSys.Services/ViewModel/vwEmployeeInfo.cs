using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSys.Services.ViewModel
{
    public class vwEmployeeInfo
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int Salary { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }
        public int id { get; set; }
        public string MemberName { get; set; }

        public string MemberRelation { get; set; }
        public long ContactNumber { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}
