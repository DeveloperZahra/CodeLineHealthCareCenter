using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Patient : User
    {
        // 1. ======================== Class Fields ==========================
        public DateTime DateOfBirth { get; set; } // Patient's date of birth


        // 2. ====================== Constructor ========================================
        public Patient(string name, DateTime dateOFBirthday, string email, string password, string nationalId, string phoneNumber, string gender, string city) 
        {
            UserCount++;
            UserId = "P" + UserCount;
            UserName = name;
            Email = email;
            Password = password;
            NationalID = nationalId;
            PhoneNumber = phoneNumber;
            Gender = gender;
            Role = "Patient";
            DateOfBirth = dateOFBirthday;
            IsActive = true;
        }

       //=======================================================




    }
}
