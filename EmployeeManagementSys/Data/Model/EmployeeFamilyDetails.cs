﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.Data.Model
{
    public class EmployeeFamilyDetails
    {
        public int id { get; set; }
        public string MemberName { get; set; }

        public string MemberRelation { get; set; }
        public long ContactNumber { get; set; }

    }
}
