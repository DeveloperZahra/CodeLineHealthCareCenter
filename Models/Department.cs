using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Department : IDepartmentService
    {
        //1. ======================================= Class Fields and attributes with properties =========================
        public int DepartmentId { get; set;}
        public string DepartmentName {  get; set;}
        public int BranchId {  get; set;}
        public static int DepartmentCount = 0;


        //2. Class Lists 
        private List<Department> departments = new List<Department>();


        //3. ======================================== Class Constructor ========================================
        public Department(string name, int branchId)
        {
            DepartmentCount++;
            DepartmentId = DepartmentCount;
            DepartmentName = name;
            BranchId = branchId;
        }
        //4. ========================================== Class Methods ================================
        /// Implement IDepartmentServices Methods 
        // 4.1 Creates a new department for the specified branch.
        public void CreateDepartment(int branchId)
        {
            Console.Write("Enter department name: ");
            string name = Console.ReadLine();

            Department newDept = new Department(name, branchId);
            departments.Add(newDept);

            Console.WriteLine($"Department '{newDept.DepartmentName}' created successfully in Branch {branchId}!");
        }

        // 4.2 Displays all departments stored in the list
        public void GetAllDepartments()
        {
            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found.");
                return;
            }

            Console.WriteLine("List of Departments:");
            foreach (var dept in departments)
            {
                Console.WriteLine($"ID: {dept.DepartmentId}, Name: {dept.DepartmentName}, Branch ID: {dept.BranchId}");
            }
        }

        //4.3 Updates an existing department's details.
        public void UpdateDepartment(int branchId, int departmentId)
        {
            Department dept = departments.FirstOrDefault(d => d.DepartmentId == departmentId && d.BranchId == branchId);

            if (dept != null)
            {
                Console.Write("Enter new department name: ");
                dept.DepartmentName = Console.ReadLine();
                Console.WriteLine("Department updated successfully!");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }

        //4.4 Changes the active status of a department.
        public void SetDepartmentActiveStatus(int departmentId, bool isActive)
        {
            Department dept = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (dept != null)
            {
                string status = isActive ? "Active" : "Inactive";
                Console.WriteLine($" Department '{dept.DepartmentName}' status set to {status}.");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }
        //4.5 Finds and displays a department by its name.
        public void GetDepartmentByName(string departmentName)
        {
            Department dept = departments.FirstOrDefault(d => d.DepartmentName.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (dept != null)
                Console.WriteLine($"Department Found: ID={dept.DepartmentId}, Branch={dept.BranchId}");
            else
                Console.WriteLine("Department not found.");
        }
        //4.6 Finds and displays a department by its ID.
        public void GetDepartmentByid(int departmentId)
        {
            Department dept = departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (dept != null)
                Console.WriteLine($"Department Found: Name={dept.DepartmentName}, Branch={dept.BranchId}");
            else
                Console.WriteLine("Department not found.");
        }
    }
}
