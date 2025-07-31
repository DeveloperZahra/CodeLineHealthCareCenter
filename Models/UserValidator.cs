using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public static class UserValidator
    {
        public static bool ValidateName(string name)
        // Validates the name of a user
        {
            if (string.IsNullOrWhiteSpace(name)) // Check if the name is null, empty, or consists only of whitespace
                return false;
            else return true;
        }

        public static bool ValidateEmail(string email) // Validates the email format of a user
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                return false; // Check if the email is null, empty, or does not contain '@' or '.'
            else return true;
        }

        public static bool ValidatePassword(string password) // Validates the password of a user
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                return false;// Check if the password is null, empty, or less than 6 characters long
            else return true;
        }

        public static bool ValidateNationalId(string nationalId) // Validates the national ID of a user
        {
            if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 3)
                return false; // Check if the national ID is null, empty, or not exactly 3 characters long

            else return true;
        }

        public static bool ValidatePhoneNumber(string phoneNumber) // Validates the phone number of a user
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 8)
                return false;// Check if the phone number is null, empty, or less than 8 characters long
            else return true;
        }

        public static bool ValidateGender(string gender) // Validates the gender of a user
        {
            if (string.IsNullOrWhiteSpace(gender) &&
                                         (gender.Equals("M", StringComparison.OrdinalIgnoreCase) ||
                                          gender.Equals("F", StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }
            else {  return true; }
        }

        public static bool ValidateRole(string role) // Validates the role of a user
        {
            if (string.IsNullOrWhiteSpace(role))
                return false; // Check if the role is null, empty, or consists only of whitespace
            else return true;
        }


        /// ================================ validate general user input data typr =================
        // 1. int data type
        public static int IntValidation(string message)
        {
            bool IntFlag;//to handle user StringNaming error input ...
            int IntInput = 0;
            do
            {
                IntFlag = false;
                try
                {
                    Console.WriteLine($"Enter {message}:");
                    IntInput = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to " + e.Message);
                    Console.ReadLine();
                    IntFlag = true;
                }

            } while (IntFlag);
            if (IntFlag)
            {
                Console.WriteLine($"{message} not accepted, please try again.");
                Console.ReadLine();
                IntInput = -1; // return -1 to indicate an error
                return IntInput; // Exit the method if input is invalid
            } 
           
            //to return tne char input ...
            return IntInput;
        }

        // 2. DateTime data type
        public static DateTime DateTimeValidation(string message)
        {
            bool DateTimeFlag; // to handle user DateTime error input
            DateTime DateTimeInput = DateTime.Now;

            do
            {
                DateTimeFlag = false;
                try
                {
                    Console.WriteLine($"Enter your {message} (format: MM/dd/yyyy):");
                    DateTimeInput = DateTime.Parse(Console.ReadLine());

                    //// Check if the date is in the future or today
                    //if (DateTimeInput.Date > DateTime.Now.Date)
                    //{
                    //    Console.WriteLine($"{message} should be a date valid.");
                    //    HoldScreen(); // just to hold a second
                    //    DateTimeFlag = true; // ask user again
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{message} not accepted due to: " + e.Message);
                    Console.ReadLine();
                    DateTimeFlag = true; // ask user again
                }
            } while (DateTimeFlag);

            return DateTimeInput; // Return the validated input
        }


    }
}
