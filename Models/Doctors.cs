using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using CodeLineHealthCareCenter.Services;
using HospitalSystemTeamTask.Services;
using CodeLineHealthCareCenter.Models;



namespace CodeLineHealthCareCenter.Models
{
    // Doctor class inherits from the base class User
    public class Doctor : User, IDoctorService
    {
        // 1. ================================ Class feilds ==================================================
        
        public string Specialty { get; set; } // The doctor's medical specialty (e.g., Cardiology, Pediatrics)     
        public int DepartmentId { get; set; }  // The ID of the department the doctor belongs to
        public int BranchId { get; set; } // The ID of the branch the doctor belongs to
        // 2. ============================== Doctor List ====================================================
        public static List<Doctor> doctors = new List<Doctor>();
        // 3. ============================= Class Constructor ================================================
        public Doctor(string name,string email,string password,string nationalId,string phoneNumber,string gender,string specialization, int branchId, int departmentId)
        : base(name, email, password, nationalId, phoneNumber, gender, "Doctor") // Call parent User constructor
        {
            // Generate a custom doctor ID (starts with "D")
            UserId = "D" + "," + UserCount;

            // Assign doctor-specific properties
            Specialty = specialization;
            BranchId = branchId;
            DepartmentId = departmentId;

            // By default, the doctor account is active
            IsActive = true;
        }


        // 4. ========================================== Doctore Methods ================================================
        /// implement method of IDoctoreServices Interface 
        // 4.1 Adds a new doctor to the system and stores it in the static list.
        public void AddDoctor(string name, string email, string password, string nationalId, string phoneNumber, string gender, string specialization, int branchId, int departmentId)
        {
            // 1️⃣ Check if a doctor with the same email already exists
            bool exists = doctors.Exists(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                Console.WriteLine("❌ Doctor with this email already exists!");
                return;
            }

            // 2️⃣ Create a new Doctor object
            Doctor newDoctor = new Doctor(name, email, password, nationalId, phoneNumber, gender, specialization, branchId, departmentId);

            // 3️⃣ Add the new doctor to the static list
            doctors.Add(newDoctor);

            // 4️⃣ Confirmation message
            Console.WriteLine($"✅ Doctor '{newDoctor.UserName}' added successfully with ID: {newDoctor.UserId}");
        }




    }
}
