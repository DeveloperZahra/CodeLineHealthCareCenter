using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    public class AuthServices
    {
        private static User currentUser = null; // Stores the currently logged-in user
        // Registers a new Patien (Sign Up).
        public static void SignUp()
        {
            Console.WriteLine("\n=== SIGN UP ===");

            // 1️⃣ Collect user input
            string name = UserData.EnterUserName();
            string email = UserData.EnterUserEmail();
            string nationalId = UserData.EnterNationalID();
            string phone = UserData.EnterPhoneNumber();
            string gender = UserData.EnterGender();
            bool isActive = UserData.EnterIsActive();
            string hashedPassword = UserData.EnterPasswordForSignUp();
            DateTime dateOfBirth = UserData.EnterDateOfBirth();

            // 2️⃣ Validate if email already exists
            if (Patient.patients.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("❌ Email already registered. Please sign in.");
                return;
            }

            // 3️. create a new Patient object
            Patient newUser = new Patient(name, dateOfBirth, email, hashedPassword ,nationalId, phone, gender)
            {
                UserName = name,
                DateOfBirth = dateOfBirth,
                Email = email,
                NationalID = nationalId,
                PhoneNumber = phone,
                Gender = gender,
                IsActive = isActive,
                Password = hashedPassword
            };

            // 4️⃣ Add user to the registered list
            Patient.patients.Add(newUser);
            Console.WriteLine($"✅ User '{name}' registered successfully!");
        }

        // Signs in an existing user by validating email and password.
        public static void SignIn()
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

            Console.WriteLine("⛔ Too many failed attempts. Please try again later.");
        }

        // Signs out the currently logged-in user.
        public static void SignOut()
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








    }
}
