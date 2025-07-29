using CodeLineHealthCareCenter.Models;
using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeLineHealthCareCenter
{
    // Base class for all users in the system (patients, doctors, admins, super admins).
    public class User : IUserService
    {
        // 1. ============== private feild ==============
        private string password;

        //2.  ============== Properties =================
        public static int UserCount = 0;
        public string UserId { get; set; } // User Id 
        public string UserName { get; set; } // name of the user
        public string Email { get; set; } // User's email address
        public string NationalID { get; set; } // National ID of the user
        public string PhoneNumber { get; set; } // Phone number of the user
        public string Gender { get; set; } // Gender for all user 
        public string Role { get; protected set; } // Role (Doctor, Patient, Admin, SuperAdmin)
        public bool IsActive { get; set; } // Account status


        // 3. ====================== Encapsulated Password ====================
        public string Password
        {
            get => password;
            set
            {
                if (value.Length >= 3)
                    password = value;
                else
                    throw new ArgumentException("Password must be at least 6 characters long.");
            }
        }

        // 4. ======================= Methods of IUserServices Interface ==========================
        /// Implement Methods which all users will 
        // 4.1 Checks if the email and password match any active user
        public bool AuthenticateUser(string email, string password, string role)
        {
            bool CanAuthenticateUser = false;
            //Use a switch statement for clarity and extensibility
            switch (role)
            {
                // Maintance the switch case if role is  Super Admin
                case "Super Admin":
                    CanAuthenticateUser= SuperAdmin.SuperAdmins.Any(u => u.Email == email && u.Password == password && u.Role == role);
                    if (CanAuthenticateUser)
                    {
                        if(SuperAdmin.SuperAdmins.Any(u => u.IsActive))
                        {
                            Console.WriteLine($"User '{email}' with role '{role}' authenticated successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Authentication failed for email '{email}' with role '{role}': Account is inactive.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Authentication failed for email '{email}'with role '{role}': email can not found");
                        return false;
                    }
                    break;
                //  Maintance the switch case if role is Admin
                case "Admin":
                    CanAuthenticateUser = Admin.Admins.Any(u => u.Email == email && u.Password == password && u.Role == role);
                    if (CanAuthenticateUser)
                    {
                        if (Admin.Admins.Any(u => u.IsActive))
                        {
                            Console.WriteLine($"User '{email}' with role '{role}' authenticated successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Authentication failed for email '{email}' with role '{role}': Account is inactive.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Authentication failed for email '{email}'with role '{role}': email can not found");
                        return false;
                    }

                    break;
                    //Maintance the switch case if role is Doctor
                case "Doctor":
                    CanAuthenticateUser = Doctor.doctors.Any(u => u.Email == email && u.Password == password && u.Role == role);
                    if (CanAuthenticateUser)
                    {
                        if (Doctor.doctors.Any(u => u.IsActive))
                        {
                            Console.WriteLine($"User '{email}' with role '{role}' authenticated successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Authentication failed for email '{email}' with role '{role}': Account is inactive.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Authentication failed for email '{email}'with role '{role}': email can not found");
                        return false;
                    }

                    break;
                    //Maintance the switch case if role is patient
                case "Patient":
                    CanAuthenticateUser = Patient.patients.Any(u => u.Email == email && u.Password == password && u.Role == role);
                    if (CanAuthenticateUser)
                    {
                        if (Patient.patients.Any(u => u.IsActive))
                        {
                            Console.WriteLine($"User '{email}' with role '{role}' authenticated successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Authentication failed for email '{email}' with role '{role}': Account is inactive.");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Authentication failed for email '{email}'with role '{role}': email can not found");
                        return false;
                    }
                    break;

                default:
                    // Log or handle unrecognized role
                    Console.WriteLine($"Authentication failed: Unrecognized role '{role}'.");
                    return false;
            }
                
        }

        // 4.2 Deactivates a user by their ID
        public void DeactivateUser(string userId ,string role)
        {
            if (role == "Super Admin")
            {
                if (SuperAdmin.SuperAdmins != null)
                {
                    var super_admin = SuperAdmin.SuperAdmins.FirstOrDefault(u => u.UserId == userId);
                    if (super_admin != null)
                        super_admin.IsActive = false;
                    else
                        Console.WriteLine($"Super Admin with this {userId} can not found");
                }
                else
                {
                    Console.WriteLine("There is no Super Admin data in the system");
                }

            }
            else if (role == "Admin")
            {
                if (Admin.Admins != null)
                {
                    var admin = Admin.Admins.FirstOrDefault(u => u.UserId == userId);
                    if (admin != null)
                        admin.IsActive = false;
                    else
                        Console.WriteLine($"Admin with this {userId} can not found");
                }
                else
                {
                    Console.WriteLine("There is no Admin data in the system");
                }
            }
            else if (role == "Doctor")
            {
                if(Doctor.doctors != null)
                {
                    var doctor = Doctor.doctors.FirstOrDefault(u => u.UserId == userId);
                    if (doctor != null)
                        doctor.IsActive = false;
                    else Console.WriteLine($"Doctor with this {userId} can not found");
                }
                else
                {
                    Console.WriteLine("There is no Doctor data in the system");
                }

            }
            else if (role == "Patient")
            {
                if (Patient.patients != null)
                {
                    var patient = Patient.patients.FirstOrDefault(u => u.UserId == userId);
                    if (patient != null)
                        patient.IsActive = false;
                    else Console.WriteLine($"Patient with this {userId} can not found");
                }
                else
                {
                    Console.WriteLine("There is no Patient data in the system");
                }
            }
            else
            {
                Console.WriteLine("No user with this role in the system");
            }


        }

        // 4.3 Checks if an email already exists in the system.
        public bool EmailExists(string email, string role)
        {
            bool EmailExists;
            switch (role)
            {
                // check email for super admin if exist
                case "Super Admin":
                    EmailExists = SuperAdmin.SuperAdmins.Any(u => u.Email == email);
                    if (EmailExists)
                    {
                        Console.WriteLine($"{role}{email} successfully exist");
                        return true;
                    }

                    else
                    {
                        Console.WriteLine($"{role}{email} dose not exist");
                        return false;
                    }
                    break;
                // check email for admin if exist
                case "Admin":
                    EmailExists = Admin.Admins.Any(u => u.Email == email);
                    if (EmailExists)
                    {
                        Console.WriteLine($"{role}{email} successfully exist");
                        return true;
                    }

                    else
                    {
                        Console.WriteLine($"{role}{email} dose not exist");
                        return false;
                    }

                    break;
                // check email for doctor if exist
                case "Doctor":
                    EmailExists = Doctor.doctors.Any(u => u.Email == email);
                    if (EmailExists)
                    {
                        Console.WriteLine($"{role}{email} successfully exist");
                        return true;
                    }

                    else
                    {
                        Console.WriteLine($"{role}{email} dose not exist");
                        return false;
                    }

                    break;
                // check email for Patient if exist
                case "Patient":
                    EmailExists = Patient.patients.Any(u => u.Email == email);
                    if (EmailExists)
                    {
                        Console.WriteLine($"{role}{email} successfully exist");
                        return true;
                    }

                    else
                    {
                        Console.WriteLine($"{role}{email} dose not exist");
                        return false;
                    }
                    break;
                default:
                    // Log or handle unrecognized role
                    Console.WriteLine($"Unrecognized role '{role}'.");
                    return false;
            }

        }

        // 4.4 function to display user data
        private void DisplayUser(User user)
        {
            Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}, Email: {user.Email}, Role: {user.Role}, Active: {user.IsActive}");
        }
        // 4.5 Prints user details by ID and role
        public void GetUserById(string userId, string role)
        {
            switch (role)
            {
                // Get Super Admin data By ID 
                case "Super Admin":
                    var Super_Admin = SuperAdmin.SuperAdmins.FirstOrDefault(u => u.UserId == userId);
                    if (Super_Admin != null)
                    {
                        DisplayUser(Super_Admin);
                    }
                    else
                    {
                        Console.WriteLine($"Not {role} in th system");
                    }
                        break;
                // Get Admin data By ID 
                case "Admin":
                    var admin = Admin.Admins.FirstOrDefault(u => u.UserId == userId);
                    if (admin != null)
                    {
                        DisplayUser(admin);
                    }
                    else
                    {
                        Console.WriteLine($"Not {role} in th system");
                    }
                    break;
                // Get Doctor data By ID 
                case "Doctor":
                    var doctor = Doctor.doctors.FirstOrDefault(u => u.UserId == userId);
                    if (doctor != null)
                    {
                        DisplayUser(doctor);
                    }
                    else
                    {
                        Console.WriteLine($"Not {role} in th system");
                    }
                    break;
                // Get Patient data By ID 

                case "Patient":
                    var patient = Patient.patients.FirstOrDefault(u => u.UserId == userId);
                    if (patient != null)
                    {
                        DisplayUser(patient);
                    }
                    else
                    {
                        Console.WriteLine($"Not {role} in th system");
                    }
                    break;
                default:
                    // unrecognized role
                    Console.WriteLine($"Unrecognized role '{role}'.");
                    return;
            }
            
        }

        //4.6 Updates a user's password if the current password matches.
        public void UpdatePassword(string userId, string role, string currentPassword, string newPassword)
        {
            switch (role)
            {
                // Updates a Super Admin's password
                case "Super Admin":
                    var Super_Admin = SuperAdmin.SuperAdmins.FirstOrDefault(u => u.UserId == userId);
                    if (Super_Admin != null && Super_Admin.Password == currentPassword)
                    {
                        Super_Admin.Password = newPassword;
                        Console.WriteLine($"Successfully update{Super_Admin.Role}password");

                    }
                    else
                    {
                        Console.WriteLine("Faild update password: not input get or currentPassword is wrong");

                    }
                    break;
                    // Updates a Admin's password
                case "Admin":
                    var admin = Admin.Admins.FirstOrDefault(u => u.UserId == userId);
                    if (admin != null && admin.Password == currentPassword)
                    {
                        admin.Password = newPassword;
                        Console.WriteLine($"Successfully update{admin.Role}password");

                    }
                    else
                    {
                        Console.WriteLine("Faild update password: not input get or currentPassword is wrong");

                    }
                    break;
                // Updates a Doctor's password

                case "Doctor":
                    var doctor = Doctor.doctors.FirstOrDefault(u => u.UserId == userId);
                    if (doctor != null && doctor.Password == currentPassword)
                    {
                        doctor.Password = newPassword;
                        Console.WriteLine($"Successfully update{doctor.Role}password");

                    }
                    else
                    {
                        Console.WriteLine("Faild update password: not input get or currentPassword is wrong");

                    }
                    break;
                // Updates a Patient's password
                case "Patient":
                    var patient = Patient.patients.FirstOrDefault(u => u.UserId == userId);
                    if (patient != null && patient.Password == currentPassword)
                    {
                        patient.Password = newPassword;
                        Console.WriteLine($"Successfully update{patient.Role}password");

                    }
                    else
                    {
                        Console.WriteLine("Faild update password: not input get or currentPassword is wrong");

                    }
                    break;
                default:
                    // unrecognized role
                    Console.WriteLine($"Unrecognized role '{role}'.");
                    return;
            }
            
        }

        // 4.7 Updates a user's details (name, email, phone, address) based on their role and userId.
        public void UpdateUser(string userId, string role)
        {
            bool hasUpdates = false;
            bool continueUpdating = true;

            while (continueUpdating)
            {
                Console.WriteLine("\nSelect the data you want to change:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Email");
                Console.WriteLine("3. Phone Number");
                Console.WriteLine("4. Address");
                Console.WriteLine("0. Cancel / Finish");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        // Assign the new value to the user later (after fetching the correct user)
                        UpdateField(userId, role, "Name", newName);
                        hasUpdates = true;
                        break;

                    case "2":
                        Console.Write("Enter new email: ");
                        string newEmail = Console.ReadLine();
                        UpdateField(userId, role, "Email", newEmail);
                        hasUpdates = true;
                        break;

                    case "3":
                        Console.Write("Enter new phone: ");
                        string newPhone = Console.ReadLine();
                        UpdateField(userId, role, "PhoneNumber", newPhone);
                        hasUpdates = true;
                        break;

                    case "4":
                        Console.Write("Enter new address: ");
                        string newAddress = Console.ReadLine();
                        UpdateField(userId, role, "Address", newAddress);
                        hasUpdates = true;
                        break;

                    case "0":
                        if (hasUpdates)
                            Console.WriteLine("\n✅ Your data has been successfully updated.");
                        else
                            Console.WriteLine("\nℹ️ No changes were made to your data.");

                        continueUpdating = false;
                        break;

                    default:
                        Console.WriteLine("\n⚠️ Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // 4.8 Helper method to update the correct user based on role and field
        private void UpdateField(string userId, string role, string field, string newValue)
        {
            object user = null;

            // Fetch user based on role
            switch (role)
            {
                case "Super Admin":
                    user = SuperAdmin.SuperAdmins.FirstOrDefault(u => u.UserId == userId);
                    break;
                case "Admin":
                    user = Admin.Admins.FirstOrDefault(u => u.UserId == userId);
                    break;
                case "Doctor":
                    user = Doctor.doctors.FirstOrDefault(u => u.UserId == userId);
                    break;
                case "Patient":
                    user = Patient.patients.FirstOrDefault(u => u.UserId == userId);
                    break;
                default:
                    Console.WriteLine($"⚠️ Unrecognized role '{role}'.");
                    return;
            }

            if (user == null)
            {
                Console.WriteLine($"⚠️ No user found with ID {userId} for role {role}.");
                return;
            }

            // Update the selected field dynamically
            var property = user.GetType().GetProperty(field);
            if (property != null && property.CanWrite)
            {
                property.SetValue(user, newValue);
            }
            else
            {
                Console.WriteLine($"⚠️ Cannot update the field '{field}'.");
            }
        }






    }
}
