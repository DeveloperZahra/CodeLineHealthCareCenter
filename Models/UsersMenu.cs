using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    public  class UsersMenu
    {
        // =================== SuperAdmin Menu ====================
        static void SuperAdminMenu()
        {
            // Flag to control the loop and allow the user to go back
            bool back = false;

            // Keep showing the menu until the user chooses to go back
            while (!back)
            {
                // Display SuperAdmin menu options with icons
                Console.WriteLine("\n👑 SuperAdmin Dashboard:");
                Console.WriteLine("1. Add Branch");
                Console.WriteLine("2. Add Department");
                Console.WriteLine("3. Add Admin");
                Console.WriteLine("4. View System Data");
                Console.WriteLine("0. Back");

                // Prompt the user to choose an option
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                // Process the user's input using a switch statement
                switch (input)
                {
                    case "1":
                        // Placeholder for adding a new branch
                        Console.WriteLine("🔧 [SuperAdmin] Add Branch - Not implemented");
                        break;
                        


                    case "2":
                        // Placeholder for adding a new department
                        Console.WriteLine("🔧 [SuperAdmin] Add Department - Not implemented");
                        break;


                    // Placeholder for adding a new admin user
                    case "3":
                        Console.WriteLine("🔧 [SuperAdmin] Add Admin - Not implemented");
                        break;


                    case "4":
                        // Placeholder for viewing overall system data
                        Console.WriteLine("📊 [SuperAdmin] View System Data - Not implemented");
                        break;

                    case "0":
                        // Exit the menu loop and return to the previous screen
                        back = true;
                        break;

                    default:
                        // Handle invalid input from the user
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }



        // =================== Admin Menu ====================
        static void AdminMenu()
        {
            // A flag to keep the menu running until the user chooses to go back
            bool back = false;

            // Loop to display the Admin menu continuously
            while (!back)
            {
                // Display Admin dashboard menu 
                Console.WriteLine("\n🛠 Admin Dashboard:");
                Console.WriteLine("1. Add Doctor");  // Option to add a new doctor
                Console.WriteLine("2. Add Clinic"); // Option to add a new clinic
                Console.WriteLine("3. View Appointments");   // Option to view appointment schedule
                Console.WriteLine("0. Back");   // Option to go back to the previous menu

                // Prompt the user to select an option
                Console.Write("Choose: ");
                string input = Console.ReadLine(); // Read user input from the console


                // Evaluate the user's choice using switch-case
                switch (input)
                {
                    case "1":
                        // Placeholder action for adding a doctor
                        Console.WriteLine("🩺 [Admin] Add Doctor - Not implemented");
                        break;


                    case "2":
                        // Placeholder action for adding a clinic
                        Console.WriteLine("🏥 [Admin] Add Clinic - Not implemented");
                        break;

                    case "3":
                        // Placeholder action for viewing appointments
                        Console.WriteLine("📅 [Admin] View Appointments - Not implemented");
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }





















    }
}
