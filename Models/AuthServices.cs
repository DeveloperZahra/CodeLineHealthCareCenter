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

            string SuperAdminCode = "5566"; // Predefined code for Super Admin

            // object to access Super Admin methods
            SuperAdmin CallToMethodSuperAdmin = new SuperAdmin();
            Patient CallToMethodPatient = new Patient();
            // Step 1: Ask user to select the type of account
            Console.WriteLine("Select User Type to Sign Up:");
            Console.WriteLine("1. Super Admin");
            Console.WriteLine("2. Patient");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            // Step 2: Super Admin Sign-Up
            if (choice == "1")
            {
                // Ask user for the Super Admin code
                Console.Write("Enter Super Admin Code: ");
                string enteredCode = Console.ReadLine();

                // Validate if the entered code is a valid integer
                int parsedCode;
                bool isNumeric = int.TryParse(enteredCode, out parsedCode);

                if (!isNumeric || parsedCode != int.Parse(SuperAdminCode))
                {
                    Console.WriteLine("Invalid Super Admin Code. Registration failed.");
                    return;
                }

                Console.WriteLine("Super Admin Code is valid. Proceeding with registration...");

                // Collect user input data
                string name = UserData.EnterUserName();
                string email = UserData.EnterUserEmail();
                string nationalId = UserData.EnterNationalID();
                string phone = UserData.EnterPhoneNumber();
                string gender = UserData.EnterGender();
                //bool isActive = UserData.EnterIsActive();
                string hashedPassword = UserData.EnterPasswordForSignUp();

                // Check if email already exists in SuperAdmin list
                if (SuperAdmin.SuperAdmins.Any(sa => sa.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Email already registered as Super Admin. Please sign in.");
                    return;
                }
                CallToMethodSuperAdmin.AddSuperAdmin(name, email, hashedPassword, nationalId, phone, gender);
                Console.WriteLine($"Super Admin '{name}' registered successfully!");
                Console.ReadLine();

            }

            // Step 3: Patient Sign-Up
            else if (choice == "2")
            {
                // Collect user input data
                string name = UserData.EnterUserName();
                string email = UserData.EnterUserEmail();
                string nationalId = UserData.EnterNationalID();
                string phone = UserData.EnterPhoneNumber();
                string gender = UserData.EnterGender();
                //bool isActive = UserData.EnterIsActive();
                string hashedPassword = UserData.EnterPasswordForSignUp();
                DateTime dateOfBirth = UserData.EnterDateOfBirth();

                // Check if email already exists in Patients list
                if (Patient.patients.Any(p => p.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Email already registered as Patient. Please sign in.");
                    return;
                }

                CallToMethodPatient.AddPatient(name, dateOfBirth, email, hashedPassword, nationalId, phone, gender);
                Console.WriteLine($"Super Patient '{name}' registered successfully!");
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
                Console.WriteLine("❌ Email not found. Please Sign Up first.");
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
                    Console.WriteLine($"\n✅ Welcome, {foundUser.UserName}! You are logged in as {foundUser.Role}.");
                    SetCurrentUser(foundUser);
                    switch (foundUser.Role)
                    {
                        case "Super Admin":
                            Console.WriteLine(" =============== Welcome to Super Admin Menu ================");
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
                    Console.WriteLine($"\n❌ Incorrect password. Attempts left: {3 - tries}");
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
