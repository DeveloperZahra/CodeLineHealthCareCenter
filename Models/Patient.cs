using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Patient : User, IPatientService
    {
        // 1. ======================== Class Fields ==========================
        public DateTime DateOfBirth { get; set; } // Patient's date of birth

        // 2. ======================== Patient List ============================
        public static List<Patient> patients = new List<Patient>();

        // 3. ====================== Constructor ========================================
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

        //4. ================================================ Patients Methods ===================================
        /// implement method in IPatientServices Interface
        // 4.1 Adds a new patient to the system.
        public void AddPatient(string name, DateTime dateOfBirth, string email, string password, string nationalId, string phoneNumber, string gender, string city)
        {
            // Check if patient with the same email already exists
            bool exists = patients.Exists(p => p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                Console.WriteLine("Patient with this email already exists!");
                return;
            }

            // Create a new Patient object
            Patient newPatient = new Patient(name, dateOfBirth, email, password, nationalId, phoneNumber, gender, city);

            // Add to the static list
            patients.Add(newPatient);

            // Confirmation message
            Console.WriteLine($"Patient '{newPatient.UserName}' added successfully with ID: {newPatient.UserId}");
        }



    }
}
