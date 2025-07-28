using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Patient : User
    {
        // 1. Class Fields
        public DateTime dateOfBirth; // Patient's date of birth
        public bool gender; // Patient's gender (Male, Female)

        // 2. Class Properties
        public DateTime DateOfBirth // Patient's date of birth
        {
            get { return dateOfBirth; } 
            set { dateOfBirth = value; } 
        }

        public bool Gender //Patient's for Gender 
        {
            get { return gender; }
            set { gender = value; }
        }

        // 3. Class Constructor

        // Default constructor
        public Patient() { }

        // Constructor with parameters
        public Patient(int id, string fullName, string email, string password, DateTime dateOfBirth, bool gender) 
        {
            this.Id = id; // Unique identifier for the patient
            this.FullName = fullName; // Patient's full name
            this.Email = email;
            this.Password = password;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
        }




    }
}
