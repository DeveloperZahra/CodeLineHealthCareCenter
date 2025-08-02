using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeLineHealthCareCenter.Models
{
    public  class UsersMenu
    {
        // =================== SuperAdmin Menu ====================
        public static void SuperAdminMenu()
        {
            
            // Create branch oject to call methods in classes
            Branch CallMethodFromBranch = new Branch(); // object to be able to call those methods( which are non static methods) in this class in other class
            Department CallMethodFromDepartment = new Department(); // object to be able to call those methods( which are non static methods) in this class in other class
            Admin CallMethodFromAdmin = new Admin(); // Create an instance of the Admin class to access its methods
            Doctor CallMethodFromDoctor = new Doctor(); // Create an instance of the Doctor class to access its methods
            User CallMethodFromUser = new User(); // Create an instance of the User class to access its methods
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
                Console.WriteLine("5. More...");
                Console.WriteLine("0. SignOut");

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
                    // Placeholder for additional options in the SuperAdmin menu
                    case "5":
                        bool backToSuperAdminMenu = false; // Flag to control the loop

                        // Use a while loop that keeps running until the user chooses to go back
                        while (!backToSuperAdminMenu)
                        {
                            Console.Clear();
                            Console.WriteLine("=== View Data Categories ===");
                            Console.WriteLine("1. View and manage branches");      // Option to view all branches
                            Console.WriteLine("2. View and manage departments");   // Option to view all departments
                            Console.WriteLine("3. View and manage Admins");        // Option to view all admins
                            Console.WriteLine("4. View and manage Doctor");       // Option to view all doctors
                            Console.WriteLine("0. Back");               // Option to return to the previous menu
                            Console.Write("Choose: ");
                            string choice = Console.ReadLine();         // Read the user's choice

                            switch (choice)
                            {
                                // Case to view and manage branches
                                case "1":
                                    bool backToViewDataCategoriesMenu = false; // Flag to control the loop for viewing data categories
                                    while (!backToViewDataCategoriesMenu)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("=== Manage Branches ===");
                                        Console.WriteLine("1. View All Branches");      // Option to view all branches
                                        Console.WriteLine("2. Get Branch Details");   // option to view branch details by ID or name
                                        Console.WriteLine("3. Get Branch Name ");        // Option to view banch name by id
                                        Console.WriteLine("4. Set Branch Status ");       // Option to set branch status by id and new value of isActive
                                        Console.WriteLine("5. Delete Branch");       // Option to delete a branch by ID
                                        Console.WriteLine("6. Update Branch");       // Option to update branch details by ID
                                        Console.WriteLine("7. Get Totle Number of branch"); // Option to get the total number of branches
                                        Console.WriteLine("0. Back");               // Option to return to the previous menu
                                        Console.Write("Choose: ");
                                        string choice1 = Console.ReadLine();         // Read the user's choice

                                        switch (choice1)
                                        {
                                            case "1":
                                                // View all branches
                                                CallMethodFromBranch.GetAllBranches();
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                // Ask the user to enter Branch ID or Name
                                                Console.Write("Enter Branch ID or Name: ");
                                                string inputBranchIdOrName = Console.ReadLine();

                                                // Try to parse the input as an integer
                                                if (int.TryParse(inputBranchIdOrName, out int branchId))
                                                {
                                                    // If parsing succeeds → input is an integer → call the method with int parameter
                                                    CallMethodFromBranch.GetBranchDetails(branchId);
                                                }
                                                else
                                                {
                                                    // If parsing fails → input is a string → call the method with string parameter
                                                    CallMethodFromBranch.GetBranchDetails(input);
                                                }

                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "3":
                                                // Get branch name by ID
                                                Console.Write("Enter Branch ID : ");
                                                int branchIdForName = int.Parse(Console.ReadLine());
                                                CallMethodFromBranch.GetBranchName(branchIdForName);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "4":
                                                // Set branch status
                                                Console.Write("Enter Branch ID: ");
                                                int branchIdForStatus = int.Parse(Console.ReadLine());
                                                Console.Write("Enter new status (true for open, false for closed): ");
                                                bool newStatus = UserData.EnterStatus(); // Get the new status from user input
                                                CallMethodFromBranch.SetBranchStatus(branchIdForStatus, newStatus);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "5":
                                                // Delete a branch
                                                Console.Write("Enter Branch ID to delete: ");
                                                int branchIdToDelete = int.Parse(Console.ReadLine());
                                                CallMethodFromBranch.DeleteBranch(branchIdToDelete);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "6":
                                                // Update branch details
                                                Console.Write("Enter Branch ID to update: ");
                                                int branchIdToUpdate = int.Parse(Console.ReadLine());
                                                CallMethodFromBranch.UpdateBranch(branchIdToUpdate);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "7":
                                                // Get the total number of branches
                                                int totalBranches = CallMethodFromBranch.GetTotalBranches();
                                                Console.WriteLine($"Total number of branches: {totalBranches}");
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "0":
                                                // Exit the loop and return to the SuperAdmin menu
                                                backToViewDataCategoriesMenu = true;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice. Please try again.");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }
                                    break;
                                // Case to view and manage departments
                                case "2":
                                    bool backToViewDataCategoriesMenu2 = false; // Flag to control the loop for viewing data categories
                                    while (!backToViewDataCategoriesMenu2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("=== Manage departments ===");
                                        Console.WriteLine("1. View All Departments");      // Option to view all departments
                                        Console.WriteLine("2. Get Department Details");   // option to view department details by ID or name
                                        Console.WriteLine("3. Update Department"); // Option to update department details by ID
                                        Console.WriteLine("4. Set Department Active Status"); // Option to set department active status by ID and new value of isActive
                                        Console.WriteLine("5. Get Department Name"); // Option to get department name by ID
                                        Console.WriteLine("0. Back");               // Option to return to the previous menu

                                        string choice2 = Console.ReadLine();         // Read the user's choice
                                        switch (choice2)
                                        {
                                            case "1":
                                                // View all departments
                                                CallMethodFromDepartment.GetAllDepartments();
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                // Ask the user to enter Department ID or Name
                                                Console.Write("Enter Department ID or Name: ");
                                                string inputDepartmentIdOrName = Console.ReadLine();
                                                // Try to parse the input as an integer
                                                if (int.TryParse(inputDepartmentIdOrName, out int departmentId))
                                                {
                                                    // If parsing succeeds → input is an integer → call the method with int parameter
                                                    CallMethodFromDepartment.GetDepartmentDetail(departmentId);
                                                }
                                                else
                                                {
                                                    // If parsing fails → input is a string → call the method with string parameter
                                                    CallMethodFromDepartment.GetDepartmentDetail(inputDepartmentIdOrName);
                                                }
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "3":
                                                // Update department details

                                                int BranchID = UserData.EnterBranchId(Branch.branches);
                                                int DepartmentID = UserData.EnterDepartmentId(BranchDepartment.Departments);

                                                CallMethodFromDepartment.UpdateDepartment(BranchID, DepartmentID);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "4":
                                                // Set department active status

                                                int departmentIdForStatus = UserData.EnterDepartmentId(BranchDepartment.Departments); // Get the department ID from user input
                                                bool newStatus = UserData.EnterStatus(); // Get the new status from user input
                                                CallMethodFromDepartment.SetDepartmentActiveStatus(departmentIdForStatus, newStatus);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "5":
                                                // Get department name by ID
                                                int departmentIdForName = UserData.EnterDepartmentId(BranchDepartment.Departments); // Get the department ID from user input
                                                CallMethodFromDepartment.GetDepartmentName(departmentIdForName);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "0":
                                                // Exit the loop and return to the SuperAdmin menu
                                                backToViewDataCategoriesMenu2 = true;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice. Please try again.");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }


                                    // View all departments
                                    CallMethodFromDepartment.GetAllDepartments();
                                    Console.WriteLine("\nPress Enter to continue...");
                                    Console.ReadLine();
                                    break;
                                // Case to view and manage admins
                                case "3":
                                    bool backToViewDataCategoriesMenu3 = false; // Flag to control the loop for viewing data categories
                                    while (!backToViewDataCategoriesMenu3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("=== Manage Admins ===");
                                        Console.WriteLine("1. View All Admins");      // Option to view all admins
                                        Console.WriteLine("2. Get Admin Details");   // option to view admin details by ID 
                                        Console.WriteLine("3. Update Admin"); // Option to update admin details by ID
                                        Console.WriteLine("4. Remove Admin"); // Option to remove an admin by ID
                                        Console.WriteLine("5. View Admins By Branch"); // Option to view admins by branch
                                        Console.WriteLine("6. View Admins By Department"); // Option to view admins by department
                                        Console.WriteLine("0. Back");               // Option to return to the previous menu
                                        string choice3 = Console.ReadLine();         // Read the user's choice

                                        switch (choice3)
                                        {
                                            case "1":
                                                // View all admins
                                                CallMethodFromAdmin.ViewAllAdmins();
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                // Get admin details by ID
                                                int adminId = UserData.EnterUserId(); // Get the admin ID from user input
                                                CallMethodFromAdmin.ViewAdmin(adminId);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "3":
                                                // Update admin details by ID

                                                int adminIdToUpdate = UserData.EnterUserId(); // Get the admin ID from user input

                                                CallMethodFromAdmin.UpdateAdmin(adminIdToUpdate);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "4":
                                                // Remove an admin by ID
                                                int adminIdToRemove = UserData.EnterUserId();
                                                CallMethodFromAdmin.RemoveAdmin(adminIdToRemove);
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "5":
                                                // View admins by branch
                                                int BranchId = UserData.EnterBranchId(Branch.branches); // Get the branch ID from user input
                                                CallMethodFromAdmin.ViewAdminsByBranch(BranchId); // Call the method to view admins by branch
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "6":
                                                // View admins by department
                                                int DepartmentId = UserData.EnterDepartmentId(BranchDepartment.Departments); // Get the department ID from user input
                                                CallMethodFromAdmin.ViewAdminsByDepartment(DepartmentId); // Call the method to view admins by department
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "0":
                                                // Exit the loop and return to the SuperAdmin menu
                                                backToViewDataCategoriesMenu3 = true;
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice. Please try again.");
                                                Console.ReadLine();
                                                break;
                                        }
                                    }
                                    
                                    break;

                                // Case to view and manage doctors
                                case "4":
                                    bool backToViewDataCategoriesMenu4 = false; // Flag to control the loop for viewing data categories
                                    while (!backToViewDataCategoriesMenu4)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("=== Manage Doctors ===");
                                        Console.WriteLine("1. View All Doctors");      // Option to view all doctors
                                        Console.WriteLine("2. Get Doctor Details");   // option to view doctor details by ID
                                        Console.WriteLine("3. Update Doctor"); // Option to delete a doctor by ID
                                        Console.WriteLine("0. back"); // Option to go back to the previous menu
                                        string choice4 = Console.ReadLine();         // Read the user's choice
                                        switch (choice4)
                                        {
                                            case "1":
                                                // View all doctors
                                                CallMethodFromUser.GetUsersByRole("Doctor");
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "2":
                                                // Get doctor details by ID
                                                int doctorId = UserData.EnterUserId(); // Get the doctor ID from user input
                                                CallMethodFromUser.GetUserById(doctorId, "Doctor"); // Call the method to get doctor details
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "3":
                                                // Delete a doctor by ID
                                                int doctorIdToDelete = UserData.EnterUserId(); // Get the doctor ID from user input
                                                CallMethodFromUser.UpdateUser(doctorIdToDelete, "Doctor"); // Call the method to delete the doctor
                                                Console.WriteLine("\nPress Enter to continue...");
                                                Console.ReadLine();
                                                break;
                                            case "0":
                                                // Exit the loop and return to the SuperAdmin menu
                                                backToViewDataCategoriesMenu4 = true;
                                                break;
                                        }
                                    } 
                                  break;
                                     

                                case "0":
                                            // Exit the loop and return to the SuperAdmin menu
                                            backToSuperAdminMenu = true;
                                            break;

                                default:
                                            Console.WriteLine("Invalid choice. Please try again.");
                                            Console.ReadLine();
                                            break;
                            }
                        }
                            
                    break;

                    case "0":
                        // Exit the menu loop and return to the previous screen
                        AuthServices auth = new AuthServices();
                        auth.SignOut();  // If non-static method
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
        public static void AdminMenu()
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
        public static void DoctorMenu()
        {
            Booking CallMethodFromBooking = new Booking(); // Create an instance of the Booking class to access its methods
            Branch branchService = new Branch(); // Create a new instance of the Branch class to access its methods and manage branch-related operations

            // A flag used to keep the menu active until the user chooses to go back
            bool back = false;


            // Loop to continuously display the Doctor menu until the user exits
            while (!back)
            {
                Console.Clear(); // Clear the console to refresh the screen for a cleaner user interface

                // Display the Doctor dashboard with options
                Console.WriteLine("\n🩺 Doctor Dashboard:"); // Display the Doctor's dashboard header
                Console.WriteLine("1. View Appointments");  // Option for doctor to view their scheduled appointments
                Console.WriteLine("2. Update Appointment Status"); // Show menu option to update the status of a specific appointment (e.g., completed, canceled)
                // Optional menu option for the doctor to view available branches in the system
                Console.WriteLine("3. View Branches");  // Useful if the doctor needs branch-related info
                Console.WriteLine("0. Back");  // Option to go back to the previous screen/menu

                // Prompt user for their choice
                Console.Write("Choose: ");
                string input = Console.ReadLine(); // Read the input from the console

                // Process the input using switch-case
                switch (input)
                {
                    case "1":
                        // Prompt the user to enter the doctor's ID to view their appointments
                        int doctorId = UserData.EnterUserId(); // Get the doctor's ID from user input
                        CallMethodFromBooking.GetBookingsByDoctorId(doctorId); // Call the method to get appointments for the specified doctor ID
                        Console.WriteLine("\nPress Enter to continue..."); // Prompt the user to press Enter before continuing, useful for pausing the screen
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                        case "2":
                        // Prompt the user to enter the appointment/booking ID they want to update
                        int bookingId = UserData.EnterBookingId(); // Enter the booking ID
                        // Prompt the user to enter the new status for the selected appointment (e.g., Completed, Canceled)
                        string newStatus = UserData.EnterAppointmentStatus(); // Enter the new appointment status
                        bookingService.UpdateBookingStatus(bookingId, newStatus);   // Call the method to update the status of the specified booking
                        Console.WriteLine("\nPress Enter to continue..."); // Prompt the user to press Enter before returning to the menu
                        Console.ReadLine();   // Wait for user input to pause the screen                                                  // 

                        break;

                    case "3":
                        branchService.GetAllBranches();  // Call the method that retrieves and displays a list of all branches in the system
                        Console.WriteLine("\nPress Enter to continue...");  // Prompt the user to press Enter so they have time to read the output
                        Console.ReadLine();
                        // Pause execution until the user presses Enter
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
        public static void PatientMenu()
        {
            Booking CallMethodFromBooking = new Booking(); // Create an instance of the Booking class to access its methods
            Branch branchService = new Branch(); // Create a new instance of the Branch class to access branch-related methods and data

            // Boolean flag used to control when to exit the menu
            bool back = false;

            // Loop that displays the menu until the user chooses to go back
            while (!back)
            {
                Console.Clear(); // Clear the console screen to refresh the UI before displaying the Patient Dashboard
                // Display the Patient dashboard with available options
                Console.WriteLine("\n🧑‍⚕️ Patient Dashboard:"); // Display the header for the Patient Dashboard
                Console.WriteLine("1. Book Appointment");  // Option to book a new appointment
                Console.WriteLine("2. View My Appointments");   // Option to view all appointments booked by the patient
                Console.WriteLine("3. Cancel Appointment"); // Show option to allow the patient to cancel an existing appointment
                Console.WriteLine("4. View Branches"); // Show option to allow the patient to view available branches in the healthcare system
                Console.WriteLine("0. Back");  // Option to return to the previous menu

                // Ask the user to enter their choice
                Console.Write("Choose: ");
                string input = Console.ReadLine(); // Read the user's input

                // Use switch-case to handle user selection
                switch (input)
                {
                    case "1":
                        CallMethodFromBooking.BookAppointment(); // Call the method to book a new appointment 
                        Console.WriteLine("\nPress Enter to continue..."); // Display a message prompting the user to press Enter before proceeding
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "2":
                        int patientId = UserData.EnterUserId(); // Get the patient's ID from user input
                        CallMethodFromBooking.GetBookingsByDoctorId(patientId); // Call the method to view all appointments booked by the patient
                        Console.WriteLine("\nPress Enter to continue..."); // Display a message prompting the user to press Enter before proceeding
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "3":
                        int bookingId = UserData.EnterBookingId();// Prompt the user to enter the booking ID and store it in the variable bookingId
                        CallMethodFromBooking.CancelAppointment(); // Call the method to cancel the specified appointment
                        Console.WriteLine("\nPress Enter to continue..."); // Display a message prompting the user to press Enter before proceeding
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "0":
                        // User selected to go back, so we set the flag to true to exit the loop
                        back = true;
                        break;

                    default:
                        // Handle invalid input that doesn't match any case
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}


















   

