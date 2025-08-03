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
            Role = "Admin"; // Set the role to Admin
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

        // 4.2 Removes an Admin user by their ID.
        public void RemoveAdmin(int adminId)
        {
            // Find the admin by ID
            Admin adminToRemove = Admins.FirstOrDefault(a => a.UserId == adminId);
            if (adminToRemove != null)
            {
                // Remove the admin from the list
                Admins.Remove(adminToRemove);
                Console.WriteLine($"Admin with ID {adminId} has been removed.");
            }
            else
            {
                Console.WriteLine($"Admin with ID {adminId} not found.");
            }
        }

        // 4.3 Updates an Admin's details by their ID.
        public void UpdateAdmin(int adminId)
        {
            // 1. Find the admin by ID
            Admin adminToUpdate = Admins.FirstOrDefault(a => a.UserId == adminId);

            if (adminToUpdate == null)
            {
                Console.WriteLine("❌ Admin not found.");
                return;
            }

            Console.WriteLine("\n=== UPDATE ADMIN DETAILS ===");
            Console.WriteLine("Leave input empty to keep the current value.\n");

            // 2. Update Name
            string newName = UserData.EnterName("new admin");
            if (newName != "null" && !string.IsNullOrWhiteSpace(newName))
                adminToUpdate.UserName = newName;

            // 3. Update Email (check uniqueness)
            string newEmail = UserData.EnterUserEmail();
            if (newEmail != "null" && !string.IsNullOrWhiteSpace(newEmail))
            {
                bool emailExists = Admins.Any(a =>
                    a.Email.Equals(newEmail, StringComparison.OrdinalIgnoreCase) && a.UserId != adminId);

                if (emailExists)
                {
                    Console.WriteLine("❌ Email already exists. Update cancelled.");
                    return;
                }
                adminToUpdate.Email = newEmail;
            }

            // 4. Update Phone (check uniqueness)
            string newPhone = UserData.EnterPhoneNumber();
            if (newPhone != "null" && !string.IsNullOrWhiteSpace(newPhone))
            {
                bool phoneExists = Admins.Any(a =>
                    a.PhoneNumber.Equals(newPhone, StringComparison.OrdinalIgnoreCase) && a.UserId != adminId);

                if (phoneExists)
                {
                    Console.WriteLine("❌ Phone number already exists. Update cancelled.");
                    return;
                }
                adminToUpdate.PhoneNumber = newPhone;
            }

            // 5. Confirmation
            Console.WriteLine($"Admin '{adminToUpdate.UserName}' updated successfully!");

            //  6. Save changes to file (Best Practice)
            FileManager.SaveDataToFile(Admins, "admins.json");
            Console.WriteLine(" Changes saved to file.");
        }

        // 4.4 Views details of a specific Admin by their ID.
        public void ViewAdmin(int adminId)
        {
            Admin admin = Admins.FirstOrDefault(a => a.UserId == adminId);

            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
                return;
            }
            Console.WriteLine("\n=== ADMIN DETAILS ===");
            Console.WriteLine($"ID: {admin.UserId}");
            Console.WriteLine($"Name: {admin.UserName}");
            Console.WriteLine($"Email: {admin.Email}");
            Console.WriteLine($"Phone: {admin.PhoneNumber}");
            Console.WriteLine($"National ID: {admin.NationalID}");
            Console.WriteLine($"Branch ID: {admin.BranchId}");
            Console.WriteLine($"Department ID: {admin.DepartmentId}");

        }

        // 4.5 Views all Admins in the system.
        public void ViewAllAdmins()
        {
            if (Admins.Count == 0)
            {
                Console.WriteLine("❌ No admins found.");
                return;
            }
            Console.WriteLine("\n=== ALL ADMINS ===");
            foreach (var admin in Admins)
            {
                Console.WriteLine($"ID: {admin.UserId}, Name: {admin.UserName}, Email: {admin.Email}, Phone: {admin.PhoneNumber}");
            }
        }

        // 4.6 Views all Admins in a specific branch.
        public void ViewAdminsByBranch(int branchId)
        {
            var branchAdmins = Admins.Where(a => a.BranchId == branchId).ToList();
            if (branchAdmins.Count == 0)
            {
                Console.WriteLine($"❌ No admins found in Branch ID: {branchId}");
                return;
            }
            Console.WriteLine($"\n=== ADMINS IN BRANCH {branchId} ===");
            foreach (var admin in branchAdmins)
            {
                Console.WriteLine($"ID: {admin.UserId}, Name: {admin.UserName}, Email: {admin.Email}, Phone: {admin.PhoneNumber}");
            }
        }

        // 4.7 Views all Admins in a specific department.
        public void ViewAdminsByDepartment(int departmentId)
        {
            var departmentAdmins = Admins.Where(a => a.DepartmentId == departmentId).ToList();
            if (departmentAdmins.Count == 0)
            {
                Console.WriteLine($" No admins found in Department ID: {departmentId}");
                return;
            }
            Console.WriteLine($"\n=== ADMINS IN DEPARTMENT {departmentId} ===");
            foreach (var admin in departmentAdmins)
            {
                Console.WriteLine($"ID: {admin.UserId}, Name: {admin.UserName}, Email: {admin.Email}, Phone: {admin.PhoneNumber}");
            }
        }





    }
}
