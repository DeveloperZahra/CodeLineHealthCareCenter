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
        // ================================ Class feilds ==================================================
        
        public string Specialty { get; set; } // The doctor's medical specialty (e.g., Cardiology, Pediatrics)     
        public int DepartmentId { get; set; }  // The ID of the department the doctor belongs to
        public int BranchId { get; set; } // The ID of the branch the doctor belongs to

        // ============================= Class Constructor ================================================
        public Doctor(string name, string email, string password, string nationalId, string phoneNumber, string specialization, int branchId, int departmentId)
        {
            UserCount++;
            UserId = "D" + UserCount;
            UserName = name ;
            Email = email ;
            Password = password ;
            NationalID = nationalId ;
            PhoneNumber = phoneNumber ;
            Specialty = specialization;
            BranchId = branchId ;
            DepartmentId = departmentId ;
            Role = "Doctor";
            IsActive = true ;
        }

       
        // ==========================================================================================

        // Method to simulate viewing appointments for this doctor
        //public void ViewAppointments()
        //{
        //    Console.WriteLine($"Doctor {FullName} is viewing their appointments...");
        //    // Here you would add logic to retrieve appointments from a list or database
        //}

        //// Method to display doctor information
        //public void DisplayInfo()
        //{
        //    Console.WriteLine("=== Doctor Information ===");
        //    Console.WriteLine($"ID         : {Id}");
        //    Console.WriteLine($"Name       : {FullName}");
        //    Console.WriteLine($"Email      : {Email}");
        //    Console.WriteLine($"Specialty  : {Specialty}");
        //    Console.WriteLine($"Department : {DepartmentId}");
        //    Console.WriteLine("==========================");
        //}



    }
}
