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
            ShowWelcomeScreen(); // Show the main menu to the user
        }

        // Displays the main welcome screen with SignUp, SignIn, and Exit options
        static void ShowWelcomeScreen()
        {
            var CallMethodsfromauthServices = new AuthServices(); // Create an instance of AuthServices to handle user authentication
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
                string input = Console.ReadLine();

                // switch condition to control user movemenet 
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("============= Sign Up  ====================");
                        CallMethodsfromauthServices.SignUp();
                        PauseForUser(); // Pause for user input after sign-up
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("============= SignIp ====================");
                        CallMethodsfromauthServices.SignIn();
                        PauseForUser(); // Pause for user input after sign-in
                        break;
                    case "0":
                        Console.WriteLine("Thank you for using CodeLine HealthCare. Goodbye!");
                        FileManager.SaveAllData();
                        isRunning = false; // Exit the loop
                        return;
                    default:
                        Console.WriteLine("\n❌ Invalid input! Please enter 1, 2, or 0.");
                        PauseForUser();
                        break;
                }

            }
        }

        // Waits for user input before continuing
        static void PauseForUser()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

    }
}
