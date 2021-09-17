using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSysApi.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        public string Username { get; internal set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
