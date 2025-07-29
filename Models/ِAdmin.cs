using CodeLineHealthCareCenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CodeLineHealthCareCenter.Models
{
    // The Admin class inherits from the base User class.
    // Represents a user with administrative privileges over a specific department and branch.
    public class Admin : User, IAdminServices
    {
        // ================================== Class feilds ===========================
        
        public int BranchId { get; set; } // The branch this admin is assigned to 
        public int DepartmentId { get; set; }  // The department this admin manages

        // ================================= Class Constructor ==========================
        public Admin(string name, string email, string password, string nationalId, string phoneNumber,int branchId, int departmentId)
        {
            UserCount++;
            UserId = "A" + UserCount;
            UserName = name ;
            Email = email ;
            Password = password ;
            NationalID = nationalId ;
            PhoneNumber = phoneNumber ;
            Role = "Admin";
            BranchId = branchId ;
            DepartmentId = departmentId ;
            IsActive = true ;
        }
        //===========================================================================================================

        //// Add a doctor only if they belong to the same branch and department as the admin
        //public void AddDoctor(Doctor doctor)
        //{
        //    if (doctor.BranchId == this.BranchId && doctor.DepartmentId == this.DepartmentId)
        //    {
        //        doctors.Add(doctor);
        //        Console.WriteLine($"Doctor {doctor.FullName} added successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error: Doctor must belong to the same branch and department as the Admin.");
        //    }
        //}


        //// Add a clinic only if it belongs to the same branch and department
        //public void AddClinic(Clinic clinic)
        //{
        //    if (clinic.BranchId == this.BranchId && clinic.DepartmentId == this.DepartmentId)
        //    {
        //        clinics.Add(clinic);
        //        Console.WriteLine($"Clinic '{clinic.Name}' added successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error: Clinic must belong to the same branch and department as the Admin.");
        //    }
        //}


        //// View all appointments related to this department
        //public void ViewDepartmentAppointments()
        //{
        //    Console.WriteLine($"\n--- Appointments for Department {DepartmentId} ---");

        //    var filteredAppointments = appointments
        //        .Where(a => a.DepartmentId == this.DepartmentId && a.BranchId == this.BranchId)
        //        .ToList();

        //    if (filteredAppointments.Count == 0)
        //    {
        //        Console.WriteLine("No appointments found.");
        //        return;
        //    }

        //    foreach (var appt in filteredAppointments)
        //    {
        //        Console.WriteLine($"Appointment ID: {appt.Id}, Patient: {appt.PatientName}, Doctor ID: {appt.DoctorId}, Time: {appt.DateTime}");
        //    }
        //}

        //// Optionally: Add appointment to the list (for testing or internal use)
        //public void AddAppointment(Appointment appointment)
        //{
        //    if (appointment.BranchId == this.BranchId && appointment.DepartmentId == this.DepartmentId)
        //    {
        //        appointments.Add(appointment);
        //    }
        //}

    }
}
