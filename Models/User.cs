using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool AuthenticateUser(string email, string password, string Role)
        {
            
           
        }



    }
}
