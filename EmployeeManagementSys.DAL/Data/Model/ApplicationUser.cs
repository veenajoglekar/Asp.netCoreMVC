﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSys.DAL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Boolean isAdmin { get; set; }
    }
}
