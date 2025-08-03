using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystemTeamTask.Services;
using CodeLineHealthCareCenter.Services;
using CodeLineHealthCareCenter.Utilities;


namespace CodeLineHealthCareCenter
{
    // SuperAdmin class that inherits from User and has full control over the system
    public class SuperAdmin : User , ISuperAdminSevices
    {
        // 1. ================================== Super Admin List ========================== 
        public static List<SuperAdmin> SuperAdmins = new List<SuperAdmin>();

        // 2. ================================= Constructore ======================================
        /// defualt constructor
        public SuperAdmin() : base() // Call parent User constructor
        {
            // Generate a custom SuperAdmin ID (starts with "SA")
            UserId = UserCount;
            // SuperAdmin accounts are active by default
            IsActive = true;
            Role = "Super Admin"; // Set the role to Super Admin
        }
        public SuperAdmin(string name, string email, string password, string nationalId, string phoneNumber, string gender)
        : base(name, email, password, nationalId, phoneNumber, gender, "Super Admin") // Call parent User constructor
        {
            // Generate a custom SuperAdmin ID (starts with "SA")
            UserId = UserCount;

            // SuperAdmin accounts are active by default
            IsActive = true;
        }

        // 3.=========================================== Super Admin Methods ================================================
        /// Implement menthod ISuperAdmin Interface 
        //3.1 Adds a new SuperAdmin to the system and stores it in the static list.

        public void AddSuperAdmin(string name, string email, string password, string nationalId, string phoneNumber, string gender)
        {
            // 1️⃣ Check if email already exists
            bool exists = SuperAdmins.Exists(sa => sa.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                Console.WriteLine("Super Admin with this email already exists!");
                return;
            }

            // 2️⃣ Create new SuperAdmin object
            SuperAdmin newSuperAdmin = new SuperAdmin(name, email, password, nationalId, phoneNumber, gender);

            // 3️⃣ Add to static list
            SuperAdmins.Add(newSuperAdmin);


            //Console.WriteLine($"Super Admin '{newSuperAdmin.UserName}' added successfully with ID: {newSuperAdmin.UserId}");
        }






       
    }
}



       