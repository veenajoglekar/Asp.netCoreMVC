using EmployeeManagementSys.DAL.Data.Model;
using EmployeeManagementSys.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EmployeeManagementSys.DAL.Data
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
        public EmployeeManagementDbContext()
        {
        }

        //public IConfiguration Configuration;
        //public EmployeeManagementDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeFamilyDetails> EmployeeFamilyDetails { get; set; }
        public DbSet<EmployeeAdvn> EmployeeAdvn { get; set; }
        public DbSet<EmpFamilyDetAdvn> EmpFamilyDetAdvn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-JGBU5O3N\\SQLEXPRESS;Database=EmployeeManagementSys;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

    }
  
}
