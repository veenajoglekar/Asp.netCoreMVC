using EmployeeManagementSys.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSys.Services.Services
{


    public interface ISharedService
    {
        public void setUser(ApplicationUser user);

        public ApplicationUser getUser();
    }
    public class sharedService : ISharedService
    {
        public ApplicationUser userDet;
        public void setUser(ApplicationUser user)
        {
            userDet = user;
        }

        public ApplicationUser getUser()
        {
            return userDet;
        }
    }
}
