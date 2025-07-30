using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public static class UserValidator
    {
        public static void ValidateName(string name)
        // Validates the name of a user
        {
            if (string.IsNullOrWhiteSpace(name)) // Check if the name is null, empty, or consists only of whitespace
                throw new ArgumentException("Name cannot be empty."); 
        }

        public static void ValidateEmail(string email) // Validates the email format of a user
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains(".")) 
                throw new ArgumentException("Invalid email format."); // Check if the email is null, empty, or does not contain '@' or '.'
        }

        public static void ValidatePassword(string password) // Validates the password of a user
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");// Check if the password is null, empty, or less than 6 characters long
        }

        public static void ValidateNationalId(string nationalId) // Validates the national ID of a user
        {
            if (string.IsNullOrWhiteSpace(nationalId) || nationalId.Length != 10)
                throw new ArgumentException("National ID must be 10 digits."); // Check if the national ID is null, empty, or not exactly 10 characters long
        }

        public static void ValidatePhoneNumber(string phoneNumber) // Validates the phone number of a user
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 8)
                throw new ArgumentException("Phone number must be at least 8 digits.");// Check if the phone number is null, empty, or less than 8 characters long
        }

        public static void ValidateGender(string gender) // Validates the gender of a user
        {
            if (string.IsNullOrWhiteSpace(gender))
                throw new ArgumentException("Gender cannot be empty."); 
        }

        public static void ValidateRole(string role) // Validates the role of a user
        {
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be empty."); // Check if the role is null, empty, or consists only of whitespace
        }


    }
}
