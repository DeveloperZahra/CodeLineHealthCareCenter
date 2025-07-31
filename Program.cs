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
            FileManager.LoadAllData(); // Load all data from files at the start of the program
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
                        FileManager.SaveAllData();
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
