using CodeLineHealthCareCenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CodeLineHealthCareCenter.Models;
using CodeLineHealthCareCenter.Utilities;


namespace CodeLineHealthCareCenter.Models
{
    // The Admin class inherits from the base User class.
    // Represents a user with administrative privileges over a specific department and branch.
    public class Admin : User, IAdminServices
    {
        // 1. ================================== Class feilds ===========================
        
        public int BranchId { get; set; } // The branch this admin is assigned to 
        public int DepartmentId { get; set; }  // The department this admin manages
        // 2. ============================== Admin List =================================
        public static List<Admin> Admins = new List<Admin>();
        // 3. ================================= Class Constructor ==========================
        /// defualt constructor
        public Admin() : base() // Call parent User constructor
        {
            // Generate a custom Admin ID (starts with "A")
            UserId = UserCount;
            // Admin accounts are active by default
            IsActive = true;
        }
        public Admin(string name, string email, string password, string nationalId, string phoneNumber, string gender, int branchId, int departmentId)
        : base(name, email, password, nationalId, phoneNumber, gender, "Admin") // Call parent User constructor
        {
            // Generate a custom Admin ID (starts with "A")
            UserId = UserCount;

            // Assign admin-specific properties
            BranchId = branchId;
            DepartmentId = departmentId;

            // Admin accounts are active by default
            IsActive = true;
        }
        //4. ==================================================== Admins Methods =======================================================
        /// implement method in IAdminService 
        // 4.1 Adds a new Admin user to the system.
        public void AddAdmin(string name, string email, string password, string nationalId, string phoneNumber, string gender, int branchId, int departmentId)
        {
            // 1️⃣ Check if an admin with the same email already exists
            bool exists = Admins.Exists(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                Console.WriteLine("❌ Admin with this email already exists!");
                return;
            }

            // 2️⃣ Create new Admin object
            Admin newAdmin = new Admin(name, email, password, nationalId, phoneNumber, gender, branchId, departmentId);

            // 3️⃣ Add the new admin to the static list
            Admins.Add(newAdmin);

            // 4️⃣ Confirmation message
            Console.WriteLine($"Admin '{newAdmin.UserName}' added successfully with ID: {newAdmin.UserId}");
        }


    }
}
