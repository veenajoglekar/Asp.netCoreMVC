using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.DAL.Data.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(100)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        public int Salary{ get; set; }

        public string Address{ get; set; }

        public string Role { get; set; }
    }
}
