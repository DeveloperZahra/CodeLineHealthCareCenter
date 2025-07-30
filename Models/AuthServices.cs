using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    public class AuthServices
    {
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

        
    }
}
