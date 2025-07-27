using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // Class representing a SuperAdmin user who has the highest level of access
    public class SuperAdmin
    {
        // Override the base GetRole method to return the specific role
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
    }
}
