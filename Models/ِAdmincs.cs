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
    public class _ِAdmincs
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





    }
}
