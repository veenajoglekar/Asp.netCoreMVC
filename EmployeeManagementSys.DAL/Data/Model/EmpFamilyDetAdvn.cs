using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace EmployeeManagementSys.DAL.Data.Model
{
    public class EmpFamilyDetAdvn
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        public int Salary { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }
       
        public string MemberName { get; set; }

        public string MemberRelation { get; set; }
        public long ContactNumber { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("EmpFamilyDetAdvn")]
        [Display(Name = "Employee Name")]
        public virtual EmployeeAdvn EmployeeAdvn { get; set; }
    }
}
