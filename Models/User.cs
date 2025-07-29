using CodeLineHealthCareCenter.Models;
using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

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
                // check email for admin if exist
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

                case "Admin":
                    EmailExists = Admin.Admins.Any(u => u.Email == email);
                    if (EmailExists)
                        return true;
                    else
                        Console.WriteLine($"{role}{email} dose not exist");
                    break;

                case "Doctor":
                    EmailExists = Doctor.doctors.Any(u => u.Email == email);
                    if (EmailExists)
                        return true;
                    else
                        Console.WriteLine($"{role}{email} dose not exist");
                    break;
                    break;

                case "Patient":

                    break;
                default:
                    // Log or handle unrecognized role
                    Console.WriteLine($"Unrecognized role '{role}'.");
                    return false;
            }

        }



    }
}
