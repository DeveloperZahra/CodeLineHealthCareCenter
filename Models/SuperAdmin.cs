using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystemTeamTask.Services;
using CodeLineHealthCareCenter.Services;


namespace CodeLineHealthCareCenter
{
    // SuperAdmin class that inherits from User and has full control over the system
    public class SuperAdmin : User , ISuperAdminSevices
    {
        // list to store super admin data 
        public List<SuperAdmin> SuperAdmins = new List<SuperAdmin>();

        // constructore 
        public SuperAdmin (string name, string email, string password, string nationalId, string phoneNumber)
        {
            UserCount++;
            UserId = "Admin" + UserCount;
            UserName = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Role = "Super Admin";
            IsActive = true;
        }

        // ===========================================================================================

        // class method ..
        public static void SuperAdminMenu()
        {

            Console.WriteLine("Welcome to SuperAdminMenu");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Add Admin");
            Console.WriteLine("3. Assign Admin To Branch");
            Console.WriteLine("4. Update Doctor");
            Console.WriteLine("5. Delete Doctor");
            Console.WriteLine("6. View Doctors");
            Console.WriteLine("7. View Admins");
            Console.WriteLine("8. Update Admin");
            Console.WriteLine("9. Delete Admin");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");

            //to get the user choice ...
            char choice = Validation.CharValidation("option");
            switch (choice)
            {

                case '1':
                    // to add new branch 
                    Console.WriteLine("Add Branch");
                    break;


                    case '2':
                    //to add a new admin ...
                    Console.WriteLine("Adding a new admin...");

                    break;

                case '3':
                    //to assign admin to branch ...
                    Console.WriteLine("Assigning admin to branch...");
                    break;


                case '4':
                    //to update doctor ...
                    Console.WriteLine("Updating doctor...");
                    break;


                case '5':
                    //to delete doctor ...
                    Console.WriteLine("Deleting doctor...");
                    break;

                case '6':
                    //to view doctors ...
                    Console.WriteLine("Viewing doctors....");
                    
                    break;

                case '7':
                    //to view admins ...
                    Console.WriteLine("Viewing admins...");
                    break;

                case '8':
                    //to update admin ...
                    Console.WriteLine("Updating admin...");
                    break;

                case '9':
                    //to delete admin ...
                    Console.WriteLine("Deleting admin...");
                    break;

                case '0':
                    Console.WriteLine("Exiting SuperAdmin Menu.");
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    Additional.HoldScreen();
                    break;

            }




        }
    }
}



        //// Method to assign a new admin to the system
        //public void AddAdmin(Admin admin)
        //{
        //    if (admin != null)
        //    {
        //        Admins.Add(admin);
        //        Console.WriteLine($"Admin '{admin.FullName}' added successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid admin data.");
        //    }
        //}

//// Method to display all stored system data
//public void ViewAllSystemData()
//{
//    Console.WriteLine("\n--- All System Data ---");

//    Console.WriteLine("\nBranches:");
//    foreach (var branch in Branches)
//    {
//        Console.WriteLine($"- ID: {branch.Id}, Name: {branch.Name}, Location: {branch.Location}");
//    }

//    Console.WriteLine("\nDepartments:");
//    foreach (var dept in Departments)
//    {
//        Console.WriteLine($"- ID: {dept.Id}, Name: {dept.Name}, Branch ID: {dept.BranchId}");
//    }

//    Console.WriteLine("\nAdmins:");
//    foreach (var admin in Admins)
//    {
//        Console.WriteLine($"- ID: {admin.Id}, Name: {admin.FullName}, Branch ID: {admin.BranchId}, Department ID: {admin.DepartmentId}");
//    }

//    Console.WriteLine("--------------------------\n");
//}