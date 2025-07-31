using CodeLineHealthCareCenter.Models;
using CodeLineHealthCareCenter.Utilities;
using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public class Department : IDepartmentService
    {
        //1. ======================================= Class Fields and attributes with properties =========================
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        private static int counter = 0; // Static counter to keep track of the number of departments created
        public List<Service> Services { get; set; } = new List<Service>(); // List to store services associated with the department


        //2. Class Lists 
        // public static List<Department> departments = new List<Department>();'
        public List<Clinic> Clinics { get; set; } = new List<Clinic>();



        //3. ======================================== Class Constructor ========================================
        public Department() // Default constructor
        {
            counter++;
            DepartmentId = counter;
            DepartmentName = "Default Department"; // Default name for the department
        }
        public Department(string name) // Constructor to initialize a new department with a name
        {
            counter++;
            DepartmentId = counter;
            DepartmentName = name;
        }
        //4. ========================================== Class Methods ================================
        /// Implement IDepartmentServices Methods 
        // 4.1 Creates a new department for the specified branch.
        public void AddDepartment()
        {
            Console.Write("Enter department name: ");
            string name = Console.ReadLine();

            Department newDept = new Department(name);
            BranchDepartment.Departments.Add(newDept);

            SaveLoadingFile.SaveToFile(BranchDepartment.Departments, SaveLoadingFile.DepartmentFile); // Save the updated list to the file

            Console.WriteLine($"Department '{newDept.DepartmentName}' created successfully!");
        }

        // 4.2 Displays all departments stored in the list
        public void GetAllDepartments()
        {
            if (BranchDepartment.Departments.Count == 0)
            {
                Console.WriteLine("No departments found.");
                return;
            }

            Console.WriteLine("List of Departments:");
            foreach (var dept in BranchDepartment.Departments)
            {
                Console.WriteLine($"ID: {dept.DepartmentId}, Name: {dept.DepartmentName}");
            }
        }

        //4.3 Updates an existing department's details.
        public void UpdateDepartment(int branchId, int departmentId)
        {
            Department dept = BranchDepartment.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);

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
            Department dept = BranchDepartment.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
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
            Department dept = BranchDepartment.Departments.FirstOrDefault(d => d.DepartmentName.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (dept != null)
                Console.WriteLine($"Department Found: ID={dept.DepartmentId}, Department Name ={dept.DepartmentName}");
            else
                Console.WriteLine("Department not found.");
        }
        //4.6 Finds and displays a department by its ID.
        public void GetDepartmentByid(int departmentId)
        {
            Department dept = BranchDepartment.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (dept != null)
                Console.WriteLine($"Department Found: Name={dept.DepartmentName}");
            else
                Console.WriteLine("Department not found.");
        }

        //4.7 Returns the name of a department by its ID.
        public string GetDepartmentName(int departmentId)
        {
            Department dept = BranchDepartment.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (dept != null)
            {
                return dept.DepartmentName;
            }
            else
            {
                return "Department not found.";
            }
        }
    }
}
