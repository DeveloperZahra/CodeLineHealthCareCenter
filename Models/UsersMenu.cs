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
            // Create branch oject to call methods in classes
            Branch CallMethodFromBranch = new Branch(); // object to be able to call those methods( which are non static methods) in this class in other class
            Department CallMethodFromDepartment = new Department(); // object to be able to call those methods( which are non static methods) in this class in other class
            Admin CallMethodFromAdmin = new Admin(); // Create an instance of the Admin class to access its methods
            Doctor CallMethodFromDoctor = new Doctor(); // Create an instance of the Doctor class to access its methods
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
                        string branchAddress = UserData.EnterAddress(); // Get the branch address from user input
                        string phoneNumber = UserData.EnterPhoneNumber(); // Get the branch phone number from user input
                        CallMethodFromBranch.AddBranch(branchAddress, phoneNumber); // Call the method to add a new branch with the provided details
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                        


                    case "2":
                        // Placeholder for adding a new department
                        CallMethodFromDepartment.AddDepartment();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;


                    // Placeholder for adding a new admin user
                    case "3":
                        // enter admin name from user input
                        string adminName = UserData.EnterUserName(); // Get the admin name from user input
                        string adminEmail = UserData.EnterUserEmail(); // Get the admin email from user input
                        string adminPassword = UserData.EnterPasswordForSignUp(); // Get the admin password from user input
                        string adminNationalId = UserData.EnterNationalID();// Get the admin national ID from user input
                        string adminPhoneNumber = UserData.EnterPhoneNumber(); // Get the admin phone number from user input
                        string adminGender = UserData.EnterGender(); // Get the admin gender from user input
                        int adminBranchId = UserData.EnterBranchId(Branch.branches); // Get the admin branch ID from user input
                        int adminDepartmentId = UserData.EnterDepartmentId(BranchDepartment.Departments); // Get the admin department ID from user input
                        CallMethodFromAdmin.AddAdmin(adminName, adminEmail, adminPassword, adminNationalId , adminPhoneNumber, adminGender, adminBranchId, adminDepartmentId); // Call the method to add a new admin with the provided details
                        Console.ReadLine(); 
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        string DName = UserData.EnterUserName(); // Get the Doctor name from user input
                        string DEmail = UserData.EnterUserEmail(); // Get the Doctor email from user input
                        string DPassword = UserData.EnterPasswordForSignUp(); // Get the Doctor password from user input
                        string DNationalId = UserData.EnterNationalID();// Get the Doctor national ID from user input
                        string DPhoneNumber = UserData.EnterPhoneNumber(); // Get the Doctor phone number from user input
                        string DGender = UserData.EnterGender(); // Get the Doctor gender from user input
                        int DBranchId = UserData.EnterBranchId(Branch.branches); // Get the Doctor branch ID from user input
                        int DDepartmentId = UserData.EnterDepartmentId(BranchDepartment.Departments); // Get the Doctor department ID from user input
                        string DSpecialization = UserData.EnterSpecialty(); // Get the doctor's specialization from user input
                        CallMethodFromDoctor.AddDoctor(DName, DEmail, DPassword, DNationalId, DPhoneNumber, DGender, DSpecialization, DBranchId, DDepartmentId); // Call the method to add a new doctor
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "0":
                        // Exit the menu loop and return to the previous screen
                        back = true;
                        break;

                    default:
                        // Handle invalid input from the user
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }



        // =================== Admin Menu ====================
        static void AdminMenu()
        {
            // Create an instance of the class to access its methods
            Clinic CallMethodFromClinic = new Clinic(); // Create an instance of the Admin class to access its methods
            Booking CallMethodFromBooking = new Booking(); // Create an instance of the Booking class to access its methods
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
                        // Prompt the user to enter clinic details
                        string clinicName = UserData.EnterUserName(); // Get the clinic name from user input
                        string clinicLocation = UserData.EnterAddress(); // Get the clinic location from user input
                        CallMethodFromClinic.AddClinic(clinicName, clinicLocation); // Call the method to add a new clinic
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "2":
                        // Placeholder for viewing appointments functionality
                        CallMethodFromBooking.GetAllBooking(); // Call the method to view all appointments
                        Console.ReadLine(); // Wait for user input before continuing
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
            Booking CallMethodFromBooking = new Booking(); // Create an instance of the Booking class to access its methods


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
                        // Prompt the user to enter the doctor's ID to view their appointments
                        Console.Write("Enter Doctor ID: ");
                        int doctorId = int.Parse(Console.ReadLine()); // Read the doctor's ID from user input

                        CallMethodFromBooking.GetBookingsByDoctorId(doctorId); // Call the method to get appointments for the specified doctor ID
                        Console.ReadLine(); // Wait for user input before continuing
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
            Booking CallMethodFromBooking = new Booking(); // Create an instance of the Booking class to access its methods

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
                        CallMethodFromBooking.BookAppointment(); // Call the method to book a new appointment
                        Console.ReadLine(); // Wait for user input before continuing
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


















   

