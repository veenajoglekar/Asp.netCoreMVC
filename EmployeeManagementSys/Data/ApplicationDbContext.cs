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
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
    public class EmployeeFamilyDetailsDbContext : DbContext
    {
        public EmployeeFamilyDetailsDbContext(DbContextOptions<EmployeeFamilyDetailsDbContext> options)
            : base(options)
        {

        }
        public DbSet<EmployeeFamilyDetails> EmployeeFamilyDetails { get; set; }
    }
}
