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
    public class Admincs
    {
        // The branch this admin is assigned to
        public int BranchId { get; set; }


        // The department this admin manages
        public int DepartmentId { get; set; }


        // Lists to manage data relevant to this admin
        private List<Doctor> doctors = new List<Doctor>();
        private List<Clinic> clinics = new List<Clinic>();
        private List<Appointment> appointments = new List<Appointment>();

        // Returns the role of this user
        public override string GetRole()
        {
            return "Admin";
        }

        // Add a doctor only if they belong to the same branch and department as the admin
        public void AddDoctor(Doctor doctor)
        {
            if (doctor.BranchId == this.BranchId && doctor.DepartmentId == this.DepartmentId)
            {
                doctors.Add(doctor);
                Console.WriteLine($"Doctor {doctor.FullName} added successfully.");
            }
            else
            {
                Console.WriteLine("Error: Doctor must belong to the same branch and department as the Admin.");
            }
        }


        // Add a clinic only if it belongs to the same branch and department
        public void AddClinic(Clinic clinic)
        {
            if (clinic.BranchId == this.BranchId && clinic.DepartmentId == this.DepartmentId)
            {
                clinics.Add(clinic);
                Console.WriteLine($"Clinic '{clinic.Name}' added successfully.");
            }
            else
            {
                Console.WriteLine("Error: Clinic must belong to the same branch and department as the Admin.");
            }
        }


        // View all appointments related to this department
        public void ViewDepartmentAppointments()
        {
            Console.WriteLine($"\n--- Appointments for Department {DepartmentId} ---");

            var filteredAppointments = appointments
                .Where(a => a.DepartmentId == this.DepartmentId && a.BranchId == this.BranchId)
                .ToList();

            if (filteredAppointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            foreach (var appt in filteredAppointments)
            {
                Console.WriteLine($"Appointment ID: {appt.Id}, Patient: {appt.PatientName}, Doctor ID: {appt.DoctorId}, Time: {appt.DateTime}");
            }
        }

        // Optionally: Add appointment to the list (for testing or internal use)
        public void AddAppointment(Appointment appointment)
        {
            if (appointment.BranchId == this.BranchId && appointment.DepartmentId == this.DepartmentId)
            {
                appointments.Add(appointment);
            }
        }

    }
}
