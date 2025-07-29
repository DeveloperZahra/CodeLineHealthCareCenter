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
            foreach (var dept in items) 
            {
                Console.WriteLine($"ID: {dept.DepartmentId}, Name: {dept.DepartmentName}"); 
            }
        }
    }
}