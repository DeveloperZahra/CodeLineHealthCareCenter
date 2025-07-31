using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                Console.Clear(); // Clear the console for a fresh display
                // Display SuperAdmin menu options with icons
                Console.WriteLine("\nSuperAdmin Dashboard:");
                Console.WriteLine("1. Add Branch");
                Console.WriteLine("2. Add Department");
                Console.WriteLine("3. Add Admin");
                Console.WriteLine("4. Add Doctor");  // Option to add a new doctor
                Console.WriteLine("5. View System Data");
                Console.WriteLine("0. Back");

                // Prompt the user to choose an option
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                // Process the user's input using a switch statement
                switch (input)

                {

                    case "1":
                        // Placeholder for adding a new branch
                        Console.WriteLine("[SuperAdmin] Add Branch - Not implemented");
                        SuperAdmin.AddSuperAdmin();
                        break;
                        


                    case "2":
                        // Placeholder for adding a new department
                        Console.WriteLine("[SuperAdmin] Add Department - Not implemented");

                        break;


                    // Placeholder for adding a new admin user
                    case "3":
                        Console.WriteLine("[SuperAdmin] Add Admin - Not implemented");
                        break;
                    case "4":
                        // Placeholder action for adding a doctor
                        Console.WriteLine("🩺 [Admin] Add Doctor - Not implemented");
                        break;
                    case "5":
                        // Placeholder for viewing overall system data
                        Console.WriteLine("[SuperAdmin] View System Data - Not implemented");
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
                Console.WriteLine("\n Admin Dashboard:");
                Console.WriteLine("1. Add Clinic"); // Option to add a new clinic
                Console.WriteLine("2. View Appointments");   // Option to view appointment schedule
                Console.WriteLine("0. Back");   // Option to go back to the previous menu

                // Prompt the user to select an option
                Console.Write("Choose: ");
                string input = Console.ReadLine(); // Read user input from the console


                // Evaluate the user's choice using switch-case
                switch (input)
                {

                    case "1":
                        // Placeholder action for adding a clinic
                        Console.WriteLine("🏥 [Admin] Add Clinic - Not implemented");
                        break;

                    case "2":
                        // Placeholder action for viewing appointments
                        Console.WriteLine("📅 [Admin] View Appointments - Not implemented");
                        break;

                    case "0":
                        // Set the flag to true to exit the menu loop
                        back = true;
                        break;

                    default:
                        // Handle any invalid menu input
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }

        // =================== Doctor Menu ====================
        static void DoctorMenu()
        {
            // A flag used to keep the menu active until the user chooses to go back
            bool back = false;


            // Loop to continuously display the Doctor menu until the user exits
            while (!back)
            {
                // Display the Doctor dashboard with options
                Console.WriteLine("\n Doctor Dashboard:");
                Console.WriteLine("1. View Appointments");  // Option for doctor to view their scheduled appointments
                Console.WriteLine("0. Back");  // Option to go back to the previous screen/menu

                // Prompt user for their choice
                Console.Write("Choose: ");
                string input = Console.ReadLine(); // Read the input from the console

                // Process the input using switch-case
                switch (input)
                {
                    case "1":
                        // Placeholder for the "View Appointments" functionality
                        Console.WriteLine("📆 [Doctor] View Appointments - Not implemented");
                        break;

                    case "0":
                        // Exit the loop and return to the previous menu
                        back = true;
                        break;


                    default:
                        // Handle invalid menu choices
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }


        // =================== Patient Menu ====================
        static void PatientMenu()
        {
            // Boolean flag used to control when to exit the menu
            bool back = false;

            // Loop that displays the menu until the user chooses to go back
            while (!back)
            {
                // Display the Patient dashboard with available options
                Console.WriteLine("\n Patient Dashboard:");
                Console.WriteLine("1. Book Appointment");  // Option to book a new appointment
                Console.WriteLine("2. View My Appointments");   // Option to view all appointments booked by the patient
                Console.WriteLine("0. Back");  // Option to return to the previous menu

                // Ask the user to enter their choice
                Console.Write("Choose: ");
                string input = Console.ReadLine(); // Read the user's input

                // Use switch-case to handle user selection
                switch (input)
                {
                    case "1":
                        // Placeholder for appointment booking functionality
                        Console.WriteLine("📅 [Patient] Book Appointment - Not implemented");
                        break;

                    case "2":
                        // Placeholder for viewing patient's own appointments
                        Console.WriteLine("📋 [Patient] View My Appointments - Not implemented");
                        break;

                    case "0":
                        // User selected to go back, so we set the flag to true to exit the loop
                        back = true;
                        break;

                    default:
                        // Handle invalid input that doesn't match any case
                        Console.WriteLine("❌ Invalid choice.");
                        break;
                }
            }
        }
    }
}


















   

