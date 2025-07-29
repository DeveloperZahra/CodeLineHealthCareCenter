using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CodeLineHealthCareCenter.Services;
using HospitalSystemTeamTask.Services;


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
        // ============================= Class Constructor ================================================
        public Doctor(string name, string email, string password, string nationalId, string phoneNumber,string gender, string specialization, int branchId, int departmentId)
        {
            UserCount++;
            UserId = "D" + UserCount;
            UserName = name ;
            Email = email ;
            Password = password ;
            NationalID = nationalId ;
            PhoneNumber = phoneNumber ;
            Gender = gender ;
            Specialty = specialization;
            BranchId = branchId ;
            DepartmentId = departmentId ;
            Role = "Doctor";
            IsActive = true ;
        }

       
        // ========================================== Doctore Methods ================================================

        



    }
}
