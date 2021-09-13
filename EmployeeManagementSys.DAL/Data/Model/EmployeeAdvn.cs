using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagementSys.DAL.Data.Model
{
    public class EmployeeAdvn
    {
        public EmployeeAdvn()
        {
            EmpFamilyDetAdvn = new HashSet<EmpFamilyDetAdvn>();
        }
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [InverseProperty("EmployeeAdvn")]
        public virtual ICollection<EmpFamilyDetAdvn> EmpFamilyDetAdvn { get; set; }
    }
}
