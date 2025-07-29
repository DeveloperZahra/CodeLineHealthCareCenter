using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public class DepartmentService : Service
    {
        // 1. Get all departments
        public void GetAllDepartments()
        {
            if (items.Count == 0) // Check if there are no departments
            {
                Console.WriteLine(" No departments found.");
                return;
            }

            Console.WriteLine(" List of Departments:");
            // Iterate through each department and print its details
            foreach (var dept in items)  // items is a List<Department> in the base class Service
            {
                Console.WriteLine($"ID: {dept.DepartmentId}, Name: {dept.DepartmentName}"); 
            }
        }

        // 2. Set department active/inactive
        public void SetActiveStatus(int departmentId, bool isActive)
        {
            var dept = items.FirstOrDefault(d => d.DepartmentId == departmentId); // Find the department by ID
            if (dept != null)
            {
                string status = isActive ? "Active" : "Inactive";
                Console.WriteLine($" Department '{dept.DepartmentName}' status set to {status}.");
            }
            else
            {
                Console.WriteLine("  Department not found."); 
            }
        }
    }
}