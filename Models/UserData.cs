using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    public class UserData
    {    public static int tries = 0;
        /// =================================== User Input Data ===============================
        // ================================== 1. User Name ====================================
        public static string EnterUserName()
        {
            string userName = "";
            int tries = 0; // Counter for the number of attempts

            try
            {
                do
                {
                    Console.Write("Enter User Name: ");
                    userName = Console.ReadLine();

                    // Check if the input is valid (not empty and at least 3 characters)
                    bool isValidName = !string.IsNullOrWhiteSpace(userName) && userName.Length >= 3;

                    if (isValidName)
                    {
                        Console.WriteLine("✅ Valid User Name.");
                        return userName; // Return the valid name
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid User Name. Please enter at least 3 characters.");
                        tries++;
                    }

                } while (tries < 3); // Allow a maximum of 3 attempts

                // If user fails 3 times
                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null"; // Return "null" to indicate failure
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return "null";
            }
        }

        // ================================== 2. Email ========================================
        public static string EnterUserEmail()
        {
            string email = "";
            int tries = 0; // Counter for attempts

            try
            {
                do
                {
                    Console.Write("Enter Email Address: ");
                    email = Console.ReadLine();

                    // ✅ Validate email format using a simple regex
                    bool isValidEmail = !string.IsNullOrWhiteSpace(email) &&
                                        Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

                    if (isValidEmail)
                    {
                        Console.WriteLine("✅ Valid Email Address.");
                        return email; // Return valid email
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid Email. Please enter a valid email (e.g., user@example.com).");
                        tries++;
                    }

                } while (tries < 3); // Maximum of 3 attempts

                // If user fails 3 times
                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return "null";
            }
        }

        // ================================== 3. NationalID ===================================
        public static string EnterNationalID()
        {
            string nationalId = "";
            int tries = 0; // Counter for attempts

            try
            {
                do
                {
                    Console.Write("Enter National ID: ");
                    nationalId = Console.ReadLine();

                    // ✅ Validate National ID: must be digits only and 10 to 14 characters long
                    bool isValidId = !string.IsNullOrWhiteSpace(nationalId) &&
                                     nationalId.All(char.IsDigit) &&
                                     (nationalId.Length == 10 || nationalId.Length == 14);

                    if (isValidId)
                    {
                        Console.WriteLine("✅ Valid National ID.");
                        return nationalId; // Return valid National ID
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid National ID. It must be 10 or 14 digits only.");
                        tries++;
                    }

                } while (tries < 3); // Allow up to 3 attempts

                // If user fails 3 times
                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return "null";
            }
        }
    }
}
