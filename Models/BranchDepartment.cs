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
        public string branchName {  get; set; }
        private string departmentName {  get; set; }


        //2. =======================Storage the relationship =================================
        private List<BranchDepartment> branchDepartments = new List<BranchDepartment>();

        //3. ======================= Class constructor =========================================
        public BranchDepartment(int branchId, int departmentId, string branchName, string departmentName, bool isActive = true)
        {
            this.branchId = branchId;
            this.departmentId = departmentId;
            this.branchName = branchName;
            this.departmentName = departmentName;
            this.isActive = isActive;
        }
        //4. ======================= Class method ============================================
        /// Implement all methods in IBranchDepartmentService interface 
        //4.1 Adds a new department to a specific branch.
        public void AddDepartmentToBranch(int branchID)
        {
            Console.Write("Enter Department ID: ");
            int departmentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the branch Name");
            string branchName = Console.ReadLine();
            Console.WriteLine("Enter the department name");
            string departmentName = Console.ReadLine();
            BranchDepartment newRelation = new BranchDepartment(branchID, departmentId, departmentName,branchName,true);
            branchDepartments.Add(newRelation);

            Console.WriteLine($" Department {departmentId} added to Branch {branchID}.");
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

        //4.3 Displays all branches that contain a specific department.
        public void GetBranchsByDepartment(int departmentId)
        {
            var branches = branchDepartments.Where(bd => bd.departmentId == departmentId).ToList();

            if (branches.Count == 0)
            {
                Console.WriteLine("No branches found for this department.");
                return;
            }

            Console.WriteLine($"Branches containing Department {departmentId}:");
            foreach (var br in branches)
            {
                Console.WriteLine($"➡ Branch ID: {br.branchId}, Status: {(br.isActive ? "Active" : "Inactive")}");
            }
        }

        // 4.4 Updates the department name in a specific branch-department relation.
        public void UpdateBranchDepartment(int branchId, int departmentId, string newDepartmentName)
        {
            BranchDepartment relation = branchDepartments.FirstOrDefault(bd => bd.branchId == branchId && bd.departmentId == departmentId);

            if (relation != null)
            {
                // update the name of department in the specific class 
                relation.departmentName = newDepartmentName;

                Console.WriteLine($"Department ID {departmentId} in Branch {branchId} updated to new name '{newDepartmentName}'.");
            
            }
            else
            {
                Console.WriteLine("Branch-Department relation not found.");
            }
        }

        // 4.5 Displays details of a specific branch-department relation.
        public void GetBranchDep(int departmentId, int branchId)
        {
            BranchDepartment relation = branchDepartments
                .FirstOrDefault(bd => bd.departmentId == departmentId && bd.branchId == branchId);

            if (relation != null)
            {
                Console.WriteLine($"Found: Branch {branchId}, Department {departmentId}, Status: {(relation.isActive ? "Active" : "Inactive")}");
            }
            else
            {
                Console.WriteLine("Relation not found.");
            }
        }


    }
}
