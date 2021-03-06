using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.DAL.Data.Model
{
    public class EmployeeFamilyDetails
    {
        public int EmployeeId { get; set; }
        public int id { get; set; }
        public string MemberName { get; set; }

        public string MemberRelation { get; set; }
        public long ContactNumber { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("EmployeeFamilyDetails")]
        public virtual Employee Employee { get; set; }

    }
}
