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
        private static User currentUser = null; // Stores the currently logged-in user
                                                // Registers a new Patien (Sign Up).
        public void SignUp()
        {
            Console.WriteLine("=== SIGN UP ===");

            // Predefined Super Admin Code
            const string SuperAdminCode = "5566";

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
                name = UserData.EnterUserName();
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
            }

            // ========== PATIENT SIGN-UP ==========
            else if (choice == "2")
            {
                // Get Name
                name = UserData.EnterUserName();
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
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }




        // Signs in an existing user by validating email and password.
        public void SignIn()
        {
            Console.WriteLine("\n=== SIGN IN ===");

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            User foundUser = SuperAdmin.SuperAdmins.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (foundUser == null)
                foundUser = Admin.Admins.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (foundUser == null)
                foundUser = Doctor.doctors.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (foundUser == null)
                foundUser = Patient.patients.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (foundUser == null)
            {
                Console.WriteLine("Email not found. Please Sign Up first.");
                Console.ReadLine();
                return;
            }

            // Verify your password (use VerifyPassword)
            int tries = 0;
            while (tries < 3)
            {
                Console.Write("Enter Password: ");
                string enteredPassword = UserData.ReadPassword();
                string HashPassw = UserData.HashPassword(enteredPassword);

                if (HashPassw == foundUser.Password)
                {
                    Console.WriteLine($"\nWelcome, {foundUser.UserName}! You are logged in as {foundUser.Role}.");
                    SetCurrentUser(foundUser);
                    switch (foundUser.Role)
                    {
                        case "Super Admin":
                            Console.WriteLine(" =============== Welcome to Super Admin Menu ================");
                            Console.ReadLine();
                            //SuperAdminMenu(foundUser);
                            break;
                        case "Admin":
                            Console.WriteLine(" =============== Welcome to Admin Menu ================");
                            //AdminMenu(foundUser);
                            break;
                        case "Doctor":
                            Console.WriteLine(" =============== Welcome to Doctor Menu ================");
                            //DoctorMenu(foundUser);
                            break;
                        case "Patient":
                            Console.WriteLine(" =============== Welcome to Patient Menu ================");
                            //PatientMenu(foundUser);
                            break;
                    }
                    return;
                }
                else
                {
                    tries++;
                    Console.WriteLine($"\nIncorrect password. Attempts left: {3 - tries}");
                }
            }

            Console.WriteLine(" Too many failed attempts. Please try again later.");
        }

        // Signs out the currently logged-in user.
        public void SignOut()
        {
            if (currentUser != null)
            {
                Console.WriteLine($"👋 User '{currentUser.UserName}' has been signed out successfully.");
                currentUser = null; // Clear the logged-in user
            }
            else
            {
                Console.WriteLine("⚠ No user is currently signed in.");
            }
        }


        // setting the current user after successful sign-in
        public static void SetCurrentUser(User user)
        {
            currentUser = user;
        }

        // getting the current user
        public static User GetCurrentUser()
        {
            return currentUser;
        }










    }
}
