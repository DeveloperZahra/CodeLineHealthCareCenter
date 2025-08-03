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
        // ================================== 1. User Name====================================
        public static string EnterName(string TypeOfName)
        {
            string userName = "";
            int tries = 0; // Counter for the number of attempts

            try
            {
                do
                {
                    Console.Write($"Enter {TypeOfName} Name: ");
                    userName = Console.ReadLine();

                    // Check if the input is valid (not empty and at least 3 characters)
                    bool isValidName = UserValidator.ValidateName(userName);

                    if (isValidName)
                    {
                        //Console.WriteLine($"Sucessfully Enter Name");
                        return userName; // Return the valid name
                    }
                    else
                    {
                        Console.WriteLine(" Invalid User Name. Please enter at least 3 characters.");
                        tries++;
                    }

                } while (tries < 3); // Allow a maximum of 3 attempts

                // If user fails 3 times
                Console.WriteLine("You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null"; // Return "null" to indicate failure
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                Console.WriteLine($" An error occurred: {ex.Message}");
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
                    Console.Write("Enter Your Email (format: emailaddress@gmail.com): ");
                    email = Console.ReadLine();

                    // Validate email format using a simple regex
                    bool isValidEmail = UserValidator.ValidateEmail(email);

                    if (isValidEmail)
                    {
                        //Console.WriteLine($"Sucessfully Enter Email");
                        return email; // Return valid email
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email. Please enter a valid email (e.g., emailaddress@example.com).");
                        tries++;
                    }

                } while (tries < 3); // Maximum of 3 attempts

                // If user fails 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null";
            }
            catch (Exception ex)
            {
                Console.WriteLine($" An error occurred: {ex.Message}");
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
                    Console.Write("Enter National ID (must be exactly 3 digit): ");
                    nationalId = Console.ReadLine();

                    //  Validate National ID: must be digits only and 10 to 14 characters long
                    bool isValidId = UserValidator.ValidateNationalId(nationalId);

                    if (isValidId)
                    {
                        Console.WriteLine($"Sucessfully Enter National ID");
                        return nationalId; // Return valid National ID
                    }
                    else
                    {
                        Console.WriteLine(" Invalid National ID. May National ID is null, empty, or not exactly 3 characters long");
                        tries++;
                    }

                } while (tries < 3); // Allow up to 3 attempts

                // If user fails 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null";
            }
            catch (Exception ex)
            {
                Console.WriteLine($" An error occurred: {ex.Message}");
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
                    Console.Write("Enter Phone Number {must be digits only and between 8 digit}: ");
                    phoneNumber = Console.ReadLine();

                    // Validate phone number: must be digits only and between 8 digits
                    bool isValidPhone = UserValidator.ValidatePhoneNumber(phoneNumber);

                    if (isValidPhone)
                    {
                        Console.WriteLine($"Sucessfully Enter Phone Nember");
                        return phoneNumber; // Return valid phone number
                    }
                    else
                    {
                        Console.WriteLine(" Invalid Phone Number. It must be at least 8 digits.");
                        tries++;
                    }

                } while (tries < 3); // Allow up to 3 attempts

                // If user fails 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null";
            }
            catch (Exception ex)
            {
                Console.WriteLine($" An error occurred: {ex.Message}");
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
                while (tries < 3) // Allow up to 3 attempts
                {
                    Console.WriteLine("Enter Gender:");
                    Console.WriteLine(" 1. Male");
                    Console.WriteLine(" 2. Female");
                    Console.Write("Select option (1 or 2): ");

                    string genderOption = Console.ReadLine()?.Trim();

                    if (genderOption == "1")
                    {
                        return "Male"; // Return immediately if valid
                    }
                    else if (genderOption == "2")
                    {
                        return "Female"; // Return immediately if valid
                    }
                    else
                    {
                        Console.WriteLine("Incorrect option selected. Please try again.");
                        tries++;
                    }
                }

                // If user fails 3 times
                Console.WriteLine("You have exceeded the maximum number of attempts.");
                return "null";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "null";
            }
        }

        // ================================== 6. Role ==========================================
        //public static string EnterRole()
        //{
        //    string role = "";
        //    int tries = 0;

        //    // Allowed roles
        //    string[] validRoles = { "Admin", "Doctor", "Patient", "Super Admin" };

        //    try
        //    {
        //        do
        //        {
        //            Console.Write("Enter Role (Admin / Doctor / Patient / Super Admin): ");
        //            role = Console.ReadLine()?.Trim();

        //            // Validate role: must match one of the valid roles (case-insensitive)
        //            bool isValidRole = UserValidator.ValidateRole(role) &&
        //                               Array.Exists(validRoles, r => r.Equals(role, StringComparison.OrdinalIgnoreCase));

        //            if (isValidRole)
        //            {
        //                // Normalize role format (capitalize first letter of each word)
        //                string formattedRole = string.Join(" ", role.Split(' ')
        //                    .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));

        //                Console.WriteLine($"Sucessfully Enter role");
        //                return formattedRole;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid Role. Please enter one of the following: Admin, Doctor, Patient, Super Admin.");
        //                tries++;
        //            }

        //        } while (tries < 3);

        //        // If user fails 3 times
        //        Console.WriteLine(" You have exceeded the maximum number of attempts.");
        //        Console.WriteLine("Please try again later.");
        //        return "null";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($" An error occurred: {ex.Message}");
        //        return "null";
        //    }
        //}
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

                    // Validate input: must be yes/no or true/false
                    if (input == "yes" || input == "true")
                    {
                        Console.WriteLine(" Account set as Active.");
                        return true;
                    }
                    else if (input == "no" || input == "false")
                    {
                        Console.WriteLine(" Account set as Inactive.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(" Invalid input. Please enter Yes or No.");
                        tries++;
                    }

                } while (tries < 3);

                // If user fails 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                Console.WriteLine("Default value set to Inactive.");
                return false; // Default to inactive if user fails
            }
            catch (Exception ex)
            {
                Console.WriteLine($" An error occurred: {ex.Message}");
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
                    password = password[..^1];
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

        //8.3 Implement the user to enter and confirm a password during sign-up.
        public static string EnterPasswordForSignUp()
        {
            int tries = 0;

            while (tries < 3)
            {
                Console.Write("Enter a new password: ");
                string password = ReadPassword();

                // Validate password (at least 6 chars, contains letter & number)
                bool validPassword = UserValidator.ValidatePassword(password);

                if (!validPassword)
                {
                    Console.WriteLine("\n Password must be at least 6 characters long and contain letters and numbers.");
                    tries++;
                    continue;
                }

                Console.Write("Confirm password: ");
                string confirmPassword = ReadPassword();

                if (password == confirmPassword)
                {
                    string hashedPassword = HashPassword(password);
                    Console.WriteLine("\n Password set successfully!");
                    return hashedPassword;
                }
                else
                {
                    Console.WriteLine("\n  Passwords do not match. Try again.");
                    tries++;
                }
            }

            Console.WriteLine("\n  You have exceeded the maximum number of attempts.");
            return "null";
        }

        // ==================================== 9.Branch ID ============================== 
        /// Input Data Specility for some users in the system 
        // Prompts the user to enter a Branch ID that must already exist in the system.
        public static int EnterBranchId(List<Branch> branches)
        {
            int tries = 0;

            try
            {
                // Show all available branches before asking for input
                if (branches == null || branches.Count == 0)
                {
                    Console.WriteLine(" No branches available.");
                    return -1;
                }

                Console.WriteLine("\n=== Available Branches ===");
                foreach (var branch in branches)
                {
                    Console.WriteLine($"ID: {branch.BranchId} | Name: {branch.BranchName}");
                }
                Console.WriteLine("==========================\n");

                // Ask user to enter branch ID
                do
                {
                    Console.Write("Enter Branch ID: ");
                    string input = Console.ReadLine();

                    // Try parsing the input to an integer
                    if (int.TryParse(input, out int branchId))
                    {
                        // Check if the branch exists
                        bool exists = branches.Any(b => b.BranchId == branchId);

                        if (exists)
                        {
                            Console.WriteLine("Successfully selected Branch ID.");
                            return branchId;
                        }
                    }

                    Console.WriteLine("Invalid Branch ID. Please enter an existing ID.");
                    tries++;

                } while (tries < 3);

                Console.WriteLine("You have exceeded the maximum number of attempts.");
                return -1; // Return -1 if attempts exceeded
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
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
                            Console.WriteLine($"Sucessfully Enter Department ID");
                            return departmentId; // Return valid department ID
                        }
                    }

                    // If the input is invalid or department not found
                    Console.WriteLine(" Invalid Department ID. Please enter an existing ID.");
                    tries++; // Increase the number of failed attempts

                } while (tries < 3); // Allow a maximum of 3 attempts

                // If user failed 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                return -1; // Indicate failure
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine($" An error occurred: {ex.Message}");
                return -1; // Indicate failure
            }
        }

        // =================================== 11. Specialty =================================
        /// Input Data Specility for doctore
        // Displays a list of available specialties and allows the user to select one by entering its number.
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
                            Console.WriteLine($"You selected: {selectedSpecialty}");
                            return selectedSpecialty;
                        }
                    }

                    // If input is invalid
                    Console.WriteLine("Invalid selection. Please enter a valid number.");
                    tries++;

                } while (tries < 3); // Allow up to 3 attempts

                Console.WriteLine("You have exceeded the maximum number of attempts.");
                return "null"; // Indicate failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "null";
            }
        }

        // =================================== 12. Date Of Birth ================================
        /// Input Data Specility for Patient
        // Implement the user to enter their Date of Birth (DOB) with validation and limited attempts.
        public static DateTime EnterDateOfBirth()
        {
            int tries = 0;

            try
            {
                do
                {
                    Console.Write("Enter Date of Birth (format: yyyy-MM-dd): ");
                    string input = Console.ReadLine();

                    // Validate date format
                    if (DateTime.TryParse(input, out DateTime dob))
                    {
                        int age = DateTime.Now.Year - dob.Year;
                        if (dob.Date > DateTime.Now.AddYears(-age)) age--; // Adjust if birthday hasn't occurred this year

                        // Validate age range (1 - 120 years)
                        if (age >= 1 && age <= 120)
                        {
                            Console.WriteLine($"Sucessfully Enter age");
                            return dob;
                        }
                        else
                        {
                            Console.WriteLine("Invalid age. Age must be between 1 and 120 years.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please use yyyy-MM-dd (e.g., 1990-05-21).");
                    }

                    tries++;

                } while (tries < 3); // Allow up to 3 attempts

                Console.WriteLine("You have exceeded the maximum number of attempts.");
                return DateTime.MinValue; // Indicate failure
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return DateTime.MinValue;
            }
        }

        // =================================== 13. Address ====================================

        public static string EnterAddress(string AddressForWhat)
        {
            string address = "";
            int tries = 0; // Counter for the number of attempts

            try
            {
                do
                {
                    Console.Write($"Enter {AddressForWhat} Address: ");
                    address = Console.ReadLine();

                    //validat fpr input data 
                    bool isValidAddress = !string.IsNullOrWhiteSpace(address) && address.Length >= 2;

                    if (isValidAddress)
                    {
                        Console.WriteLine($"Sucessfully save Enter address");
                        return address; // Return the valid address
                    }
                    else
                    {
                        Console.WriteLine(" Invalid Address. Please enter at least 5 characters.");
                        tries++;
                    }

                } while (tries < 3); // Allow a maximum of 3 attempts

                // If user fails 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                Console.WriteLine("Please try again later.");
                return "null"; // Return "null" to indicate failure
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "null";
            }
        }

        // ================================= 14. Enter status==========================
        public static bool EnterStatus()
        {
            string input = "";
            int tries = 0;
            try
            {
                do
                {
                    Console.Write("Is the branch active? (Yes/No): ");
                    input = Console.ReadLine()?.Trim().ToLower();
                    // Validate input: must be yes/no or true/false
                    if (input == "yes" || input == "true")
                    {
                        Console.WriteLine(" Branch set as Active.");
                        return true;
                    }
                    else if (input == "no" || input == "false")
                    {
                        Console.WriteLine(" Branch set as Inactive.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(" Invalid input. Please enter Yes or No.");
                        tries++;
                    }
                } while (tries < 3);
                // If user fails 3 times
                Console.WriteLine(" You have exceeded the maximum number of attempts.");
                Console.WriteLine("Default value set to Inactive.");
                return false; // Default to inactive if user fails
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Return false by default on error
            }
        }

        // =============================== 15. Enter UserId ===========================
        public static int EnterUserId()
        {
            // Combine all users into one list
            List<User> allUsers = new List<User>();
            allUsers.AddRange(SuperAdmin.SuperAdmins);
            allUsers.AddRange(Admin.Admins);
            allUsers.AddRange(Doctor.doctors);
            allUsers.AddRange(Patient.patients);

            int tries = 0; // Counter for attempts

            try
            {
                do
                {
                    Console.Write("Enter User ID: ");
                    string input = Console.ReadLine();

                    // Validate if input is a valid integer
                    if (int.TryParse(input, out int userId))
                    {
                        // Ensure UserId is treated as string before splitting
                        bool exists = allUsers.Any(u =>
                        {
                            string idAsString = u.UserId.ToString(); // Convert to string
                            string[] parts = idAsString.Split(','); // Now you can split
                            if (parts.Length > 1 && int.TryParse(parts.Last(), out int parsedId))
                                return parsedId == userId;
                            else if (int.TryParse(idAsString, out parsedId))
                                return parsedId == userId;

                            return false;
                        });

                        if (exists)
                        {
                            Console.WriteLine("User ID found successfully.");
                            return userId; // Return the valid user ID
                        }
                    }

                    // If invalid input or user not found
                    Console.WriteLine("Invalid or non-existing User ID. Please try again.");
                    tries++;

                } while (tries < 3); // Allow up to 3 attempts

                Console.WriteLine("You have exceeded the maximum number of attempts.");
                return -1; // Return -1 if attempts exceeded
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }

        internal static int EnterBookingId()
        {
            int tries = 0;

            while (tries < 3) // Allow up to 3 attempts
            {
                Console.Write("Enter Booking ID: ");
                string input = Console.ReadLine();

                // Check if input is a valid integer
                if (int.TryParse(input, out int bookingId))
                {
                    // Check if the booking exists in the list
                    bool exists = Booking.Bookings.Any(b => b.BookingId == bookingId);
                    if (exists)
                    {
                        Console.WriteLine("Booking ID found successfully.");
                        return bookingId; // Return valid booking ID
                    }
                    else
                    {
                        Console.WriteLine("Booking ID not found. Please enter a valid ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                tries++;
            }

            Console.WriteLine("Maximum attempts reached. Returning -1.");
            return -1; // Return -1 if user fails after 3 tries
        }


        internal static string EnterAppointmentStatus()
        {
            Console.WriteLine("\nSelect Appointment Status:");
            Console.WriteLine("1. Scheduled");
            Console.WriteLine("2. Completed");
            Console.WriteLine("3. Canceled");
            Console.Write("Enter your choice (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return "Scheduled";
                case "2":
                    return "Completed";
                case "3":
                    return "Canceled";
                default:
                    Console.WriteLine("❌ Invalid choice. Defaulting to 'Scheduled'.");
                    return "Scheduled";
            }
        }

    }
}
