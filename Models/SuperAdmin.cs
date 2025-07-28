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


        // Method to add a new branch to the system
        public void AddBranch(Branch branch)
        {
            if (branch != null)
            {
                Branches.Add(branch);
                Console.WriteLine($"Branch '{branch.Name}' added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid branch data.");
            }
        }

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



    }
}
