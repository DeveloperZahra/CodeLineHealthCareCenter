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
                        // Placeholder for adding a new department


                    case "2":
                        // Placeholder for adding a new admin user
                        Console.WriteLine("🔧 [SuperAdmin] Add Department - Not implemented");
                        break;
                    case "3":
                        Console.WriteLine("🔧 [SuperAdmin] Add Admin - Not implemented");
                        break;
                    case "4":
                        Console.WriteLine("📊 [SuperAdmin] View System Data - Not implemented");
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
