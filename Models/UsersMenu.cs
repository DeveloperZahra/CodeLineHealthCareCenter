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
            BranchDepartment branchDeptService = new BranchDepartment(0, 0, 0, 0, "", "");

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

                        string branchAddress = UserData.EnterAddress("Branch"); // Get the branch address from user input
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
                        // ✅ Enter admin name
                        string adminName = UserData.EnterName("Admin");
                        if (adminName == "null")
                        {
                            Console.WriteLine("Admin name is required. Process stopped.");
                            return;
                        }

                        // ✅ Enter admin email
                        string adminEmail = UserData.EnterUserEmail();
                        if (adminEmail == "null")
                        {
                            Console.WriteLine("Admin email is required. Process stopped.");
                            return;
                        }

                        // ✅ Enter admin password
                        string adminPassword = UserData.EnterPasswordForSignUp();
                        if (adminPassword == "null")
                        {
                            Console.WriteLine("Admin password is required. Process stopped.");
                            return;
                        }

                        // ✅ Enter admin national ID
                        string adminNationalId = UserData.EnterNationalID();
                        if (adminNationalId == "null")
                        {
                            Console.WriteLine("Admin national ID is required. Process stopped.");
                            return;
                        }

                        // ✅ Enter admin phone number
                        string adminPhoneNumber = UserData.EnterPhoneNumber();
                        if (adminPhoneNumber == "null")
                        {
                            Console.WriteLine("Admin phone number is required. Process stopped.");
                            return;
                        }

                        // ✅ Enter admin gender
                        string adminGender = UserData.EnterGender();
                        if (adminGender == "null")
                        {
                            Console.WriteLine("Admin gender is required. Process stopped.");
                            return;
                        }

                        // ✅ Enter branch ID
                        int adminBranchId = UserData.EnterBranchId(Branch.branches);
                        if (adminBranchId == -1)
                        {
                            Console.WriteLine("Invalid Branch ID. Process stopped.");
                            return;
                        }

                        // ✅ Enter department ID
                        int adminDepartmentId = UserData.EnterDepartmentId(BranchDepartment.Departments, adminBranchId);
                        if (adminDepartmentId == -1)
                        {
                            Console.WriteLine("Invalid Department ID. Process stopped.");
                            return;
                        }

                        // Only add admin if all inputs are valid
                        CallMethodFromAdmin.AddAdmin(
                            adminName,
                            adminEmail,
                            adminPassword,
                            adminNationalId,
                            adminPhoneNumber,
                            adminGender,
                            adminBranchId,
                            adminDepartmentId
                        );

                        Console.WriteLine("Admin added successfully!");
                        Console.ReadLine();


                        break;
                    case "4":
                        string DName = UserData.EnterName("Doctor");
                        if (DName == "null")
                        {
                            Console.WriteLine("Doctor name is Unsave. Process stopped.");
                            return;
                        }

                        string DEmail = UserData.EnterUserEmail();
                        if (DEmail == "null")
                        {
                            Console.WriteLine(" Doctor email is Unsave. Process stopped.");
                            return;
                        }

                        string DPassword = UserData.EnterPasswordForSignUp();
                        if (DPassword == "null")
                        {
                            Console.WriteLine("Doctor password is Unsave. Process stopped.");
                            return;
                        }

                        string DNationalId = UserData.EnterNationalID();
                        if (DNationalId == "null")
                        {
                            Console.WriteLine("Doctor national ID is Unsave. Process stopped.");
                            return;
                        }

                        string DPhoneNumber = UserData.EnterPhoneNumber();
                        if (DPhoneNumber == "null")
                        {
                            Console.WriteLine("Doctor phone number is Unsave. Process stopped.");
                            return;
                        }

                        string DGender = UserData.EnterGender();
                        if (DGender == "null")
                        {
                            Console.WriteLine("Doctor gender is Unsave. Process stopped.");
                            return;
                        }

                        int DBranchId = UserData.EnterBranchId(Branch.branches);
                        if (DBranchId == -1)
                        {
                            Console.WriteLine("Invalid Branch ID. Process stopped.");
                            return;
                        }

                        int DDepartmentId = UserData.EnterDepartmentId(BranchDepartment.Departments, DBranchId);
                        if (DDepartmentId == -1)
                        {
                            Console.WriteLine("Invalid Department ID. Process stopped.");
                            return;
                        }

                        string DSpecialization = UserData.EnterSpecialty();
                        if (DSpecialization == "null")
                        {
                            Console.WriteLine(" Doctor specialization is required. Process stopped.");
                            return;
                        }

                        // ✅ Only call AddDoctor if all inputs are valid
                        CallMethodFromDoctor.AddDoctor(DName, DEmail, DPassword, DNationalId, DPhoneNumber, DGender, DSpecialization, DBranchId, DDepartmentId);

                        Console.WriteLine("Doctor added successfully!");
                        Console.ReadLine();

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
                                        Console.WriteLine("8. Assign Departments to specific branch");
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
                                            case "8":
                                                // Assign departments to a specific branch
                                                int branchIdForAssignment = UserData.EnterBranchId(Branch.branches); // Get the branch ID from user input
                                                branchDeptService.AssignDepartmentsToBranch(branchIdForAssignment); // Call the method to assign departments to the specified branch
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
            bool exitMenu = false;

            while (!exitMenu)
            {
                Console.WriteLine("\n=== Clinic Management Menu ===");
                Console.WriteLine("1. Add Clinic");
                Console.WriteLine("2. View All Clinics in My Branch & Department");
                Console.WriteLine("3. View Clinic by ID");
                Console.WriteLine("4. Update Clinic Details");
                Console.WriteLine("5. Delete Clinic");
                Console.WriteLine("0. Back to Previous Menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Add Clinic ONLY for current admin's branch & department
                        string clinicName = UserData.EnterName("clinic");
                        string clinicLocation = UserData.EnterAddress("Clinic");
                        decimal price = UserValidator.DecimalValidation("Enter Clinic Price");

                        CallMethodFromClinic.AddClinic(clinicName, clinicLocation, AuthServices.currentAdmin.DepartmentId, AuthServices.currentAdmin.BranchId, 0, 0, price);
                        Console.ReadLine();
                        break;

                    case "2":
                        // Show clinics only for admin's assigned branch & department
                        var filteredClinics = Clinic.Clinics
                            .Where(c => c.BranchId == AuthServices.currentAdmin.BranchId && c.DepartmentId == AuthServices.currentAdmin.DepartmentId)
                            .ToList();

                        if (!filteredClinics.Any())
                        {
                            Console.WriteLine("No clinics found for your branch and department.");
                        }
                        else
                        {
                            Console.WriteLine($"Clinics for Branch {AuthServices.currentAdmin.BranchId} & Department {AuthServices.currentAdmin.DepartmentId}:");
                            foreach (var c in filteredClinics)
                                c.ViewClinicInfo();
                        }
                        Console.ReadLine();

                        break;

                    case "3":
                        int clinicId = UserValidator.IntValidation("Enter Clinic ID");
                        var clinic = Clinic.Clinics.FirstOrDefault(c => c.ClinicId == clinicId
                                                             && c.BranchId == AuthServices.currentAdmin.BranchId
                                                             && c.DepartmentId == AuthServices.currentAdmin.DepartmentId);
                        if (clinic != null)
                            clinic.ViewClinicInfo();
                        else
                            Console.WriteLine("Clinic not found or not in your branch/department.");
                        Console.ReadLine();

                        break;

                    case "4":
                        int updateId = UserValidator.IntValidation("Enter Clinic ID to Update");
                        var clinicToUpdate = Clinic.Clinics.FirstOrDefault(c => c.ClinicId == updateId
                                                                     && c.BranchId == AuthServices.currentAdmin.BranchId
                                                                     && c.DepartmentId == AuthServices.currentAdmin.DepartmentId);
                        if (clinicToUpdate == null)
                        {
                            Console.WriteLine(" Clinic not found or not in your branch/department.");
                            break;
                        }

                        string newName = UserData.EnterName("new clinic");
                        string newLocation = UserData.EnterAddress("New Adress");
                        decimal newPrice = UserValidator.DecimalValidation("Enter New Price");

                        CallMethodFromClinic.UpdateClinicDetails(updateId, newName, newLocation, newPrice);
                        Console.ReadLine();

                        break;

                    case "5":
                        int deleteId = UserValidator.IntValidation("Enter Clinic ID to Delete");
                        var clinicToDelete = Clinic.Clinics.FirstOrDefault(c => c.ClinicId == deleteId
                                                                     && c.BranchId == AuthServices.currentAdmin.BranchId
                                                                     && c.DepartmentId == AuthServices.currentAdmin.DepartmentId);
                        if (clinicToDelete == null)
                        {
                            Console.WriteLine("⚠ Clinic not found or not in your branch/department.");
                            break;
                        }

                        CallMethodFromClinic.DeleteClinic(deleteId);
                        Console.ReadLine();

                        break;

                    case "0":
                        exitMenu = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // =================== Doctor Menu ====================
        public static void DoctorMenu()
        {
            // ✅ Create service instances
            Booking bookingService = new Booking();
            Branch branchService = new Branch();

            // ✅ Get the currently logged-in doctor (no need to enter ID every time)
            if (AuthServices.currentDoctor == null)
            {
                Console.WriteLine("⚠ No doctor is currently signed in.");
                return;
            }

            bool exitMenu = false;

            while (!exitMenu)
            {
                Console.Clear();
                Console.WriteLine($"\n Doctor Dashboard - Welcome Dr. {AuthServices.currentDoctor.UserName}");
                Console.WriteLine("===========================================");
                Console.WriteLine("1️ View My Appointments");
                Console.WriteLine("2️ Update Appointment Status");
                Console.WriteLine("3️  View My Branch & Department Info");
                Console.WriteLine("0️  Back to Main Menu");
                Console.WriteLine("===========================================");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": //  View Appointments
                        Console.Clear();
                        bookingService.GetBookingsById(AuthServices.currentDoctor.UserId);
                        Console.WriteLine("\nPress Enter to return...");
                        Console.ReadLine();
                        break;

                    case "2": // Update Appointment Status
                        Console.Clear();
                        Console.WriteLine("=== Update Appointment Status ===");
                        int bookingId = UserData.EnterBookingId();

                        if (bookingId == -1)
                        {
                            Console.WriteLine("Invalid Booking ID.");
                        }
                        else
                        {
                            string newStatus = UserData.EnterAppointmentStatus();
                            Booking.UpdateBookingStatus(bookingId, newStatus);
                        }

                        Console.WriteLine("\nPress Enter to return...");
                        Console.ReadLine();
                        break;

                    case "3": // View Doctor’s Branch & Department Info
                        Console.Clear();
                        Console.WriteLine("=== My Branch & Department Info ===");

                        Branch myBranch = Branch.branches
                            .FirstOrDefault(b => b.BranchId == AuthServices.currentDoctor.BranchId);

                        Department myDept = BranchDepartment.Departments
                            .FirstOrDefault(d => d.DepartmentId == AuthServices.currentDoctor.DepartmentId);

                        Console.WriteLine($"Doctor Name   : Dr. {AuthServices.currentDoctor.UserName}");
                        Console.WriteLine($"Branch Name   : {myBranch?.BranchName ?? "Not Assigned"}");
                        Console.WriteLine($"Department    : {myDept?.DepartmentName ?? "Not Assigned"}");

                        Console.WriteLine("\nPress Enter to return...");
                        Console.ReadLine();
                        break;

                    case "0": // Exit
                        exitMenu = true;
                        break;

                    default:
                        Console.WriteLine(" Invalid choice. Please try again.");
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
                Console.WriteLine("\n Patient Dashboard:"); // Display the header for the Patient Dashboard
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
                        CallMethodFromBooking.GetBookingsById(patientId); // Call the method to view all appointments booked by the patient
                        Console.WriteLine("\nPress Enter to continue..."); // Display a message prompting the user to press Enter before proceeding
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "3":
                        int bookingId = UserData.EnterBookingId();// Prompt the user to enter the booking ID and store it in the variable bookingId
                        CallMethodFromBooking.CancelAppointment(); // Call the method to cancel the specified appointment
                        Console.WriteLine("\nPress Enter to continue..."); // Display a message prompting the user to press Enter before proceeding
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case "4":
                        branchService.GetAllBranches();// Call the method to retrieve and display all branches available in the system
                        Console.WriteLine("\nPress Enter to continue...");  // Prompt the user to press Enter to pause the screen and allow time to read the output
                        Console.ReadLine(); 
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


















   

