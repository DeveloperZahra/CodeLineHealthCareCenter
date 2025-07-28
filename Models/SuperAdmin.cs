using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // SuperAdmin class that inherits from User and has full control over the system
    public class SuperAdmin
    {
        // List to store all branches in the system
        private List<Branch> Branches = new List<Branch>();

        // List to store all departments
        private List<Department> Departments = new List<Department>();


        // List to store all admins
        private List<Admin> Admins = new List<Admin>();


        // Override GetRole to return the specific role of this user
        public override string GetRole()
        {
            return "SuperAdmin";
        }







    }
}
