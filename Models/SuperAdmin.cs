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

            SaveLoadingFile.SaveToFile(SuperAdmins, SaveLoadingFile.SuperAdminFile); // Save to file

            //Console.WriteLine($"Super Admin '{newSuperAdmin.UserName}' added successfully with ID: {newSuperAdmin.UserId}");
        }






        //=====================================================================
        //public static void SuperAdminMenu()
        //{

        //    Console.WriteLine("Welcome to SuperAdminMenu");
        //    Console.WriteLine("1. Add Doctor");
        //    Console.WriteLine("2. Add Admin");
        //    Console.WriteLine("3. Assign Admin To Branch");
        //    Console.WriteLine("4. Update Doctor");
        //    Console.WriteLine("5. Delete Doctor");
        //    Console.WriteLine("6. View Doctors");
        //    Console.WriteLine("7. View Admins");
        //    Console.WriteLine("8. Update Admin");
        //    Console.WriteLine("9. Delete Admin");
        //    Console.WriteLine("4. Exit");
        //    Console.Write("Please select an option: ");

        //    //to get the user choice ...
        //    char choice = Validation.CharValidation("option");
        //    switch (choice)
        //    {

        //        case '1':
        //            // to add new branch 
        //            Console.WriteLine("Add Branch");
        //            break;


        //            case '2':
        //            //to add a new admin ...
        //            Console.WriteLine("Adding a new admin...");

        //            break;

        //        case '3':
        //            //to assign admin to branch ...
        //            Console.WriteLine("Assigning admin to branch...");
        //            break;


        //        case '4':
        //            //to update doctor ...
        //            Console.WriteLine("Updating doctor...");
        //            break;


        //        case '5':
        //            //to delete doctor ...
        //            Console.WriteLine("Deleting doctor...");
        //            break;

        //        case '6':
        //            //to view doctors ...
        //            Console.WriteLine("Viewing doctors....");

        //            break;

        //        case '7':
        //            //to view admins ...
        //            Console.WriteLine("Viewing admins...");
        //            break;

        //        case '8':
        //            //to update admin ...
        //            Console.WriteLine("Updating admin...");
        //            break;

        //        case '9':
        //            //to delete admin ...
        //            Console.WriteLine("Deleting admin...");
        //            break;

        //        case '0':
        //            Console.WriteLine("Exiting SuperAdmin Menu.");
        //            break;

        //        default:
        //            Console.WriteLine("Invalid option, please try again.");
        //            Additional.HoldScreen();
        //            break;

        //    }




        //}
    }
}



       