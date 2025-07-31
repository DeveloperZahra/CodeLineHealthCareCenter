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
            SaveLoadingFile.LoadFromFile(SaveLoadingFile.DoctorFile); // Load doctors from file
            SaveLoadingFile.LoadFromFile(SaveLoadingFile.SuperAdminFile); // Load super admins from file
            SaveLoadingFile.LoadFromFile(SaveLoadingFile.PatientFile); // Load patients from file
            ShowWelcomeScreen();
        }

        // Displays the main welcome screen with SignUp, SignIn, and Exit options
        static void ShowWelcomeScreen()
        {
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
                        //SignUp();
                        break;
                    case '2':
                        Console.WriteLine("============= SignIp ====================");
                        //SignIn();
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
