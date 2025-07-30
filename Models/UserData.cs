using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography; // to can use SHA256 hash for the given password.


namespace CodeLineHealthCareCenter.Models
{
    public class UserData
    {    public static int tries = 0;
        /// =================================== General User Input Data ===============================
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
        // ================================== 7. IsActive ======================================
        public static bool EnterIsActive()
        {
            string input = "";
            int tries = 0;

            try
            {
                do
                {
                    Console.Write("Is the account active? (Yes/No): ");
                    input = Console.ReadLine()?.Trim().ToLower();

                    // ✅ Validate input: must be yes/no or true/false
                    if (input == "yes" || input == "true")
                    {
                        Console.WriteLine("✅ Account set as Active.");
                        return true;
                    }
                    else if (input == "no" || input == "false")
                    {
                        Console.WriteLine("✅ Account set as Inactive.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid input. Please enter Yes or No.");
                        tries++;
                    }

                } while (tries < 3);

                // If user fails 3 times
                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                Console.WriteLine("Default value set to Inactive.");
                return false; // Default to inactive if user fails
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return false; // Return false by default on error
            }
        }

        // ================================== 8. Password ======================================
        /// Password Methods 
        // 8.1 Reads a password from the console while masking the input.
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        // 8.2 Generates a SHA256 hash for the given password.
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
        // 8.3 Verifies if the entered password matches the stored hashed password.
        public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHashedPassword;
        }
        //8.4 Prompts the user to enter a password and validates it against the stored hash.
        public static bool EnterPasswordWithAttempts(string storedHashedPassword)
        {
            int tries = 0;

            while (tries < 3)
            {
                Console.Write("Enter your password: ");
                string enteredPassword = ReadPassword();

                if (VerifyPassword(enteredPassword, storedHashedPassword))
                {
                    Console.WriteLine("\n✅ Login successful.");
                    return true;
                }
                else
                {
                    tries++;
                    Console.WriteLine("\n❌ Incorrect password. Attempts left: " + (3 - tries));
                }
            }

            Console.WriteLine("\n⛔ You have exceeded the maximum number of attempts.");
            Console.WriteLine("Your account has been locked. Please contact admin.");
            return false;
        }

        // ==================================== 9.Branch ID ============================== 
        /// Input Data Specility for some users in the system 
        // Prompts the user to enter a Branch ID that must already exist in the system.
        public static int EnterBranchId(List<Branch> branches)
        {
            int tries = 0;

            try
            {
                do
                {
                    Console.Write("Enter Branch ID: ");
                    string input = Console.ReadLine();

                    // ✅ Try parsing the input to an integer
                    if (int.TryParse(input, out int branchId))
                    {
                        // ✅ Check if the branch exists
                        bool exists = branches.Any(b => b.BranchId == branchId);

                        if (exists)
                        {
                            Console.WriteLine("✅ Valid Branch ID.");
                            return branchId;
                        }
                    }

                    // If input is invalid or branch does not exist
                    Console.WriteLine("❌ Invalid Branch ID. Please enter an existing ID.");
                    tries++;

                } while (tries < 3);

                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                return -1; // Return -1 if attempts exceeded
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return -1;
            }
        }

        // ==================================== 10. Department ID ===============================
        /// Input Data Specility for some users in the system 
        // Prompts the user to enter a Department ID that must already exist in the system.
        public static int EnterDepartmentId(List<Department> departments)
        {
            int tries = 0; // Counter for user attempts

            try
            {
                do
                {
                    Console.Write("Enter Department ID: ");
                    string input = Console.ReadLine();

                    // Check if the entered value is a valid integer
                    if (int.TryParse(input, out int departmentId))
                    {
                        // Check if the entered department ID exists in the provided list
                        bool exists = departments.Any(d => d.DepartmentId == departmentId);

                        if (exists)
                        {
                            Console.WriteLine("✅ Valid Department ID.");
                            return departmentId; // Return valid department ID
                        }
                    }

                    // If the input is invalid or department not found
                    Console.WriteLine("❌ Invalid Department ID. Please enter an existing ID.");
                    tries++; // Increase the number of failed attempts

                } while (tries < 3); // Allow a maximum of 3 attempts

                // If user failed 3 times
                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                return -1; // Indicate failure
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return -1; // Indicate failure
            }
        }
        public static string EnterSpecialty()
        {
            // List of available specialties
                    List<string> specialties = new List<string>
            {
                "Cardiology",
                "Pediatrics",
                "Neurology",
                "Orthopedics",
                "Dermatology",
                "General Surgery",
                "Psychiatry",
                "Radiology"
            };

            int tries = 0;

            try
            {
                do
                {
                    Console.WriteLine("\nAvailable Specialties:");
                    for (int i = 0; i < specialties.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {specialties[i]}");
                    }

                    Console.Write("Select the number of the specialty: ");
                    string input = Console.ReadLine();

                    // Check if input is a valid number
                    if (int.TryParse(input, out int selectedIndex))
                    {
                        // Check if the selected index is within range
                        if (selectedIndex >= 1 && selectedIndex <= specialties.Count)
                        {
                            string selectedSpecialty = specialties[selectedIndex - 1];
                            Console.WriteLine($"✅ You selected: {selectedSpecialty}");
                            return selectedSpecialty;
                        }
                    }

                    // If input is invalid
                    Console.WriteLine("❌ Invalid selection. Please enter a valid number.");
                    tries++;

                } while (tries < 3); // Allow up to 3 attempts

                Console.WriteLine("⚠ You have exceeded the maximum number of attempts.");
                return "null"; // Indicate failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠ An error occurred: {ex.Message}");
                return "null";
            }
        }


    }
}
