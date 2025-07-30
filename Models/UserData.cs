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
        // ================================== 4. Phone Number ==================================
        public static string EnterPhoneNumber()
        {
            string phoneNumber = "";
            int tries = 0; // Counter for attempts

            try
            {
                do
                {
                    Console.Write("Enter Phone Number: ");
                    phoneNumber = Console.ReadLine();

                    // ✅ Validate phone number: must be digits only and between 8-12 digits
                    bool isValidPhone = !string.IsNullOrWhiteSpace(phoneNumber) &&
                                        phoneNumber.All(char.IsDigit) &&
                                        phoneNumber.Length >= 8 && phoneNumber.Length <= 12;

                    if (isValidPhone)
                    {
                        Console.WriteLine("✅ Valid Phone Number.");
                        return phoneNumber; // Return valid phone number
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid Phone Number. It must contain only digits and be 8-12 digits long.");
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
        // ================================== 5. Gender ========================================
        public static string EnterGender()
        {
            string gender = "";
            int tries = 0; // Counter for attempts

            try
            {
                do
                {
                    Console.Write("Enter Gender (Male/Female): ");
                    gender = Console.ReadLine()?.Trim();

                    // ✅ Validate gender: must be "Male" or "Female" (case-insensitive)
                    bool isValidGender = !string.IsNullOrWhiteSpace(gender) &&
                                         (gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                                          gender.Equals("Female", StringComparison.OrdinalIgnoreCase));

                    if (isValidGender)
                    {
                        // Normalize output to start with capital letter
                        string formattedGender = char.ToUpper(gender[0]) + gender.Substring(1).ToLower();
                        Console.WriteLine("✅ Valid Gender.");
                        return formattedGender;
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid Gender. Please enter 'Male' or 'Female'.");
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
        // ================================== 6. Role ==========================================
        public static string EnterRole()
        {
            string role = "";
            int tries = 0;

            // Allowed roles
            string[] validRoles = { "Admin", "Doctor", "Patient", "Super Admin" };

            try
            {
                do
                {
                    Console.Write("Enter Role (Admin / Doctor / Patient / Super Admin): ");
                    role = Console.ReadLine()?.Trim();

                    // ✅ Validate role: must match one of the valid roles (case-insensitive)
                    bool isValidRole = !string.IsNullOrWhiteSpace(role) &&
                                       Array.Exists(validRoles, r => r.Equals(role, StringComparison.OrdinalIgnoreCase));

                    if (isValidRole)
                    {
                        // Normalize role format (capitalize first letter of each word)
                        string formattedRole = string.Join(" ", role.Split(' ')
                            .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));

                        Console.WriteLine("✅ Valid Role.");
                        return formattedRole;
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid Role. Please enter one of the following: Admin, Doctor, Patient, Super Admin.");
                        tries++;
                    }

                } while (tries < 3);

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
