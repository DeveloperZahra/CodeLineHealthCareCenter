using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    // Doctor class inherits from the base class User
    public class Doctor : User
    {
        // The doctor's medical specialty (e.g., Cardiology, Pediatrics)
        public string Specialty { get; set; }

        // The ID of the department the doctor belongs to
    public int DepartmentId { get; set; }

        // Parameterized constructor to initialize a new doctor
        public Doctor(int id, string fullName, string email, string password, string specialty, int departmentId)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Email = email;
            this.Password = password;
            this.Specialty = specialty;
            this.DepartmentId = departmentId;
        }

        // Override GetRole method to specify this user is a Doctor
        public override string GetRole()
        {
            return "Doctor";
        }

        // Method to simulate viewing appointments for this doctor
        public void ViewAppointments()
        {

        }
}
