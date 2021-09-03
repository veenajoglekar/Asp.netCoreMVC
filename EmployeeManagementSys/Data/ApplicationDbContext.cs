using EmployeeManagementSys.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSys.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
    public class EmployeeManagementDbContext : DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeFamilyDetails> EmployeeFamilyDetails { get; set; }

    }
  
}
