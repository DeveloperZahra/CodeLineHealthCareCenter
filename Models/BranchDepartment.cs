using CodeLineHealthCareCenter.Models;
using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // Class BranchDepartment which represents the relationship between a branch and a department
    class BranchDepartment : IBranchDepartmentService
    {
        //1. ========================== class fields and their properities ==========================
        public int branchId { get; set; }
        public int departmentId {  get; set; }
        public bool isActive { get; set; }

        //2. =======================Storage the relationship =================================
        private List<BranchDepartment> branchDepartments = new List<BranchDepartment>();

        //3. ======================= Class constructor =========================================
        public BranchDepartment(int branchId, int departmentId, bool isActive = true)
        {
            this.branchId = branchId;
            this.departmentId = departmentId;
            this.isActive = isActive;
        }
        //4. ======================= Class method ============================================
        /// Implement all methods in IBranchDepartmentService interface 
        //4.1 Adds a new department to a specific branch.
        public void AddDepartmentToBranch(int branchID)
        {
            Console.Write("Enter Department ID: ");
            int departmentId = int.Parse(Console.ReadLine());

            BranchDepartment newRelation = new BranchDepartment(branchID, departmentId, true);
            branchDepartments.Add(newRelation);

            Console.WriteLine($"✅ Department {departmentId} added to Branch {branchID}.");
        }

        //4.2 Displays all departments that belong to a specific branch.
        public void GetDepartmentsByBranch(int branchID)
        {
            var departments = branchDepartments.Where(bd => bd.branchId == branchID).ToList();

            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found for this branch.");
                return;
            }

            Console.WriteLine($"Departments in Branch {branchID}:");
            foreach (var dep in departments)
            {
                Console.WriteLine($"Department ID: {dep.departmentId}, Status: {(dep.isActive ? "Active" : "Inactive")}");
            }
        }
    }
}
