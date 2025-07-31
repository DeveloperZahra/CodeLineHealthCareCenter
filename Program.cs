using System;
using System.Collections.Generic;
using CodeLineHealthCareCenter.Models;
using CodeLineHealthCareCenter.Utilities;  // Import custom models (User, Doctor, Patient, etc.)



namespace CodeLineHealthCareCenter
{
    public class Program
    {
      

        static void Main(string[] args)
        {
            Patient.patients = FileManager.LoadDataFromFile<Patient>("patients.json"); // Load patients from file
            Doctor.doctors = FileManager.LoadDataFromFile<Doctor>("doctors.json"); // Load doctors from file
            SuperAdmin.SuperAdmins = FileManager.LoadDataFromFile<SuperAdmin>("superadmins.json"); // Load super admins from file
            Admin.Admins = FileManager.LoadDataFromFile<Admin>("admins.json"); // Load admins from file
            Branch.branches= FileManager.LoadDataFromFile<Branch>("branches.json"); // Load branches from file
            BranchDepartment.Departments = FileManager.LoadDataFromFile<Department>("departments.json"); // Load departments from file
            BranchDepartment.branchDepartments = FileManager.LoadDataFromFile<BranchDepartment>("branchdepartments.json"); // Load branch-department relationships from file
            Clinic.Clinics = FileManager.LoadDataFromFile<Clinic>("clinics.json"); // Load clinics from file
            Booking.Bookings = FileManager.LoadDataFromFile<Booking>("bookings.json"); // Load bookings from file
            Service.Services = FileManager.LoadDataFromFile<Service>("services.json"); // Load services from file

            
            ShowWelcomeScreen();
        }

        // Displays the main welcome screen with SignUp, SignIn, and Exit options
        static void ShowWelcomeScreen()
        {
            AuthServices CallMethodsfromauthServices = new AuthServices(); // Create an instance of AuthServices to handle user authentication
            bool isRunning = true;
            // while loop to display wellcome screen every true value untill user enter 0 value to exist from loop 
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("==================================");
                Console.WriteLine(" Welcome to Hospital System ");
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
                        Console.WriteLine("============= SignUp ====================");
                        CallMethodsfromauthServices.SignUp();
                        break;
                    case '2':
                        Console.WriteLine("============= SignIp ====================");
                        CallMethodsfromauthServices.SignIn();
                        break;
                    case '0':
                        Console.WriteLine("Thank you for using the system!");
                        isRunning = false; // Exit the loop
                        return;
                    default:
                        //ShowError("Invalid choice! Please try again.");
                        break;
                }

            }
        }
       
    }
}
