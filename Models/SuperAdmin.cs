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

        // Method to add a new department to a specific branch
        public void AddDepartment(Department department, int branchId)
        {
            Branch targetBranch = Branches.Find(b => b.Id == branchId);
            if (targetBranch != null && department != null)
            {
                department.BranchId = branchId;
                Departments.Add(department);
                Console.WriteLine($"Department '{department.Name}' added to Branch ID: {branchId}.");
            }
            else
            {
                Console.WriteLine("Branch not found or invalid department.");
            }
        }

        // Method to assign a new admin to the system
        public void AddAdmin(Admin admin)
        {
            if (admin != null)
            {
                Admins.Add(admin);
                Console.WriteLine($"Admin '{admin.FullName}' added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid admin data.");
            }
        }







    }
}
