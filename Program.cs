using System;
using System.Collections.Generic;
using CodeLineHealthCareCenter.Models;  // Import custom models (User, Doctor, Patient, etc.)



namespace CodeLineHealthCareCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // Displays the main welcome screen with SignUp, SignIn, and Exit options
        static void ShowWelcomeScreen()
        {
            // while loop to display wellcome screen every true value untill user enter 0 value to exist from loop 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine("  🏥 Welcome to Hospital System 🏥   ");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("0. Exit");
                Console.WriteLine("----------------------------------");
                Console.Write("Enter your choice: ");

                // switch condition to control user movemenet 
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        SignUp();
                        break;
                    case '2':
                        SignIn();
                        break;
                    case '0':
                        Console.WriteLine("Thank you for using the system!");
                        return;
                    default:
                        //ShowError("Invalid choice! Please try again.");
                        break;
                }

            }
        }

        // Function to handle user registration
        static void SignUp()

        {
            Console.Clear();
            Console.WriteLine("=== Sign Up====");

            // Collect user details
            Console.Write("Full Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Ask for user role
            Console.Write("Role (Doctor / Patient / Admin / SuperAdmin): ");
            string role = Console.ReadLine().ToLower();

            User newUser = null; // Temporary holder for the new user object


            // Create appropriate object based on role
            switch (role)
            {
                // Check if the user role is "superadmin"
                case "superadmin":
                    // Create a new instance of the SuperAdmin class
                    newUser = new SuperAdmin
                    {
                        Id = users.Count + 1,
                        FullName = name,
                        Email = email,
                        Password = password
                    };
                    break;



            }

        // Create Sign In Class
        static void SignIn()
        {
            Console.WriteLine("Wellcome To SignIn....");
        }

       
    }
}
