using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CodeLineHealthCareCenter.Models;
using HospitalSystemTeamTask.Services;

namespace CodeLineHealthCareCenter.Models
{
    public class AuthServices : IAuthService
    {
        public static SuperAdmin currentSuperAdmin= null; // Stores the currently logged-in user
        public static Admin currentAdmin = null; // Stores the currently logged-in user
        public static Doctor currentDoctor = null; // Stores the currently logged-in user
        public static Patient currentPatient = null; // Stores the currently logged-in user

        private const string SuperAdminCode = "5566"; // Default Super Admin Code


        //user registration for Super Admin or Patient accounts.
        public void SignUp()
        {
            Console.WriteLine("=== SIGN UP MENU ===");

            // Ask the user to select the type of account
            Console.WriteLine("Select User Type to Sign Up:");
            Console.WriteLine("1. Super Admin");
            Console.WriteLine("2. Patient");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            // Common input variables
            string name, email, nationalId, phone, gender, hashedPassword;

            // ========== SUPER ADMIN SIGN-UP ==========
            if (choice == "1")
            {
                // Validate Super Admin Code
                Console.Write("Enter Super Admin Code: ");
                string enteredCode = Console.ReadLine();
                if (!int.TryParse(enteredCode, out int parsedCode) || parsedCode != int.Parse(SuperAdminCode))
                {
                    Console.WriteLine("Invalid Super Admin Code. Registration failed.");
                    return;
                }


                Console.WriteLine("Super Admin Code is valid. Proceeding with registration...");

                // Get Name
                name = UserData.EnterName("Super Admin");
                if (name == "null") return;

                // Get Email (Ensure uniqueness)
                do
                {
                    email = UserData.EnterUserEmail();
                    if (email == "null") return;

                    if (!UserValidator.IsEmailUnique(email))
                        Console.WriteLine("This email is already registered. Please try a different email.");
                    else
                        break;

                } while (true);

                // Get National ID (Ensure uniqueness)
                do
                {
                    nationalId = UserData.EnterNationalID();
                    if (nationalId == "null") return;

                    if (!UserValidator.IsNationalIdUnique(nationalId))
                        Console.WriteLine("This National ID is already registered. Please try a different one.");
                    else
                        break;

                } while (true);

                // Get other details
                phone = UserData.EnterPhoneNumber();
                if (phone == "null") return;

                gender = UserData.EnterGender();
                if (gender == "null") return;

                hashedPassword = UserData.EnterPasswordForSignUp();
                if (hashedPassword == "null") return;

                // Create new Super Admin and add to list
                SuperAdmin newSuperAdmin = new SuperAdmin(name, email, hashedPassword, nationalId, phone, gender);
                SuperAdmin.SuperAdmins.Add(newSuperAdmin);

                Console.WriteLine($"Super Admin '{name}' registered successfully!");
                Console.WriteLine("You can now sign in with your new Super Admin account.");
                Console.ReadLine();
            }

            // ========== PATIENT SIGN-UP ==========
            else if (choice == "2")
            {
                // Get Name
                name = UserData.EnterName("patient");
                if (name == "null") return;

                // Get Email (Ensure uniqueness)
                do
                {
                    email = UserData.EnterUserEmail();
                    if (email == "null") return;

                    if (!UserValidator.IsEmailUnique(email))
                        Console.WriteLine("This email is already registered. Please try a different email.");
                    else
                        break;

                } while (true);

                // Get National ID (Ensure uniqueness)
                do
                {
                    nationalId = UserData.EnterNationalID();
                    if (nationalId == "null") return;

                    if (!UserValidator.IsNationalIdUnique(nationalId))
                        Console.WriteLine("This National ID is already registered. Please try a different one.");
                    else
                        break;

                } while (true);

                // Get other details
                phone = UserData.EnterPhoneNumber();
                if (phone == "null") return;

                gender = UserData.EnterGender();
                if (gender == "null") return;

                hashedPassword = UserData.EnterPasswordForSignUp();
                if (hashedPassword == "null") return;

                DateTime dateOfBirth = UserData.EnterDateOfBirth();

                // Create new Patient and add to list
                Patient newPatient = new Patient(name, dateOfBirth, email, hashedPassword, nationalId, phone, gender);
                Patient.patients.Add(newPatient);

                Console.WriteLine($"Patient '{name}' registered successfully!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }




        // Signs in an existing user by validating email and password.

        public void SignIn()
        {
            // Display sign-in header
            Console.WriteLine("\n=== SIGN IN ===");

            // Step 1: Ask the user to enter their email
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            // Step 2: Collect all users from different user lists into one combined list
            List<User> allUsers = new List<User>();
            allUsers.AddRange(SuperAdmin.SuperAdmins); // Add all Super Admins
            allUsers.AddRange(Admin.Admins);           // Add all Admins
            allUsers.AddRange(Doctor.doctors);         // Add all Doctors
            allUsers.AddRange(Patient.patients);       // Add all Patients

            // Step 3: Search for the user by email (case-insensitive)
            User foundUser = allUsers.FirstOrDefault(
                u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            // Step 4: If the email does not exist, display an error and exit
            if (foundUser == null)
            {
                Console.WriteLine("Email not found. Please sign up first.");
                return;
            }

            // Step 5: Validate the password using the password verification method
            // If authentication fails after 3 attempts, exit the sign-in process
            if (!UserValidator.EnterAndCheckPassword(foundUser))
            {
                return; // Exit if password verification failed
            }

            // Step 6: If authentication is successful, greet the user
            Console.WriteLine($"\nWelcome, {foundUser.UserName}! You are logged in as {foundUser.Role}.");
            Program.PauseForUser();

            // Step 7: Store the logged-in user in the current session
            SetCurrentUser(foundUser);

            // Step 8: Navigate to the menu based on the user's role
            switch (foundUser.Role)
            {
                case "Super Admin":
                    UsersMenu.SuperAdminMenu(); // Call the Super Admin menu function
                    Program.PauseForUser();
                    break;

                case "Admin":
                    UsersMenu.AdminMenu(); // Call the Admin menu function
                    Program.PauseForUser();
                    break;

                case "Doctor":
                   UsersMenu.DoctorMenu(); // Call the Doctor menu function
                   Program.PauseForUser();
                   break;

                case "Patient":
                    UsersMenu.PatientMenu(); // Call the Patient menu function
                    Program.PauseForUser();
                    break;

                default:
                    Console.WriteLine("Role not recognized. Contact system administrator.");
                    Console.ReadLine();

                    break;
            }

            // End of SignIn method
            return;
        }




        // Signs out the currently logged-in user.
        public void SignOut()
        {
            if (currentSuperAdmin != null)
            {
                Console.WriteLine($"Super Admin '{currentSuperAdmin.UserName}' has been signed out successfully.");
                currentSuperAdmin = null;
            }
            else if (currentAdmin != null)
            {
                Console.WriteLine($"Admin '{currentAdmin.UserName}' has been signed out successfully.");
                currentAdmin = null;
            }
            else if (currentDoctor != null)
            {
                Console.WriteLine($"Doctor '{currentDoctor.UserName}' has been signed out successfully.");
                currentDoctor = null;
            }
            else if (currentPatient != null)
            {
                Console.WriteLine($"Patient '{currentPatient.UserName}' has been signed out successfully.");
                currentPatient = null;
            }
            else
            {
                Console.WriteLine(" No user is currently signed in.");
            }
        }



        // setting the current user after successful sign-in
        public static void SetCurrentUser(User user)
        {
            if (user is SuperAdmin)
            {
                currentSuperAdmin = (SuperAdmin)user;
                currentAdmin = null;
                currentDoctor = null;
                currentPatient = null;
            }
            else if (user is Admin)
            {
                currentAdmin = (Admin)user;
                currentSuperAdmin = null;
                currentDoctor = null;
                currentPatient = null;
            }
            else if (user is Doctor)
            {
                currentDoctor = (Doctor)user;
                currentSuperAdmin = null;
                currentAdmin = null;
                currentPatient = null;
            }
            else if (user is Patient)
            {
                currentPatient = (Patient)user;
                currentSuperAdmin = null;
                currentAdmin = null;
                currentDoctor = null;
            }
        }

        // getting the current user
        public static User GetCurrentUser(User user)
        {
           if (user is SuperAdmin)
            {
                return currentSuperAdmin;
            }
            else if (user is Admin)
            {
                return currentAdmin;
            }
            else if (user is Doctor)
            {
                return currentDoctor;
            }
            else if (user is Patient)
            {
                return currentPatient;
            }
            return null; // If no user matches, return null
        }










    }
}
