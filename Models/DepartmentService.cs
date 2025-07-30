using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeLineHealthCareCenter
{
    public class DepartmentService //// DepartmentService class that provides operations for Department objects directly
    {
        private List<Department> departments = new List<Department>(); // List to store all departments

        // 1. Get all departments
        public void GetAllDepartments()
        {
            if (departments.Count == 0) // Check if there are no departments
            {
                Console.WriteLine(" No departments found.");
                return;
            }

            Console.WriteLine(" List of Departments:");
            // Iterate through each department and print its details
            foreach (var dept in departments)  // items is a List<Department> in the base class Service
            {
                Console.WriteLine($"ID: {dept.DepartmentId}, Name: {dept.DepartmentName}"); 
            }
        }

        // 2. Set department active/inactive
        public void SetActiveStatus(int departmentId, bool isActive)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == departmentId); // Find the department by ID
            if (dept != null)
            {
                string status = isActive ? "Active" : "Inactive"; // Set the status based on isActive parameter
                Console.WriteLine($" Department '{dept.DepartmentName}' status set to {status}.");
            }
            else
            {
                Console.WriteLine("  Department not found."); 
            }
        }
        // 3. Get department by name
        public void GetDepartmentByName(string name) 
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentName.Equals(name, StringComparison.OrdinalIgnoreCase)); // Find the department by name
            if (dept != null)
                Console.WriteLine($" Department Found: ID = {dept.DepartmentId}, Name = {dept.DepartmentName}"); 
            else
                Console.WriteLine(" Department not found.");
        }

        // 4. Get department by ID
        public void GetDepartmentById(int id)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == id); // Find the department by ID
            if (dept != null)
                Console.WriteLine($" Department Found: Name = {dept.DepartmentName}");
            else
                Console.WriteLine(" Department not found."); 
        }


    }
}
