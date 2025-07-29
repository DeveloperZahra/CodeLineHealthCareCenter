using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Clinic
    {
        // 1. Class Fields
        public int id; // Unique identifier for the clinic
        public string name; // Name of the clinic
        public int departmentId; // ID of the department the clinic 
        public int branchId; // ID of the branch the clinic is located in

        public Dictionary<Doctor, string> doctorSchedules; // Doctor + available time


        // 2. Class Properties
        public int Id // Unique identifier for the clinic
        {
            get { return id; }
            set { id = value; }
        }
        public string Name // Name of the clinic
        {
            get { return name; }
            set { name = value; }
        }
        public int DepartmentId // ID of the department the clinic belongs to
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
        public int BranchId // ID of the branch the clinic is located in
        {
            get { return branchId; }
            set { branchId = value; }
        }
        public Dictionary<Doctor, string> DoctorSchedules // Doctor + available time
        {
            get { return doctorSchedules; } // Dictionary to hold doctor schedules with Doctor as key and available time as value
            set { doctorSchedules = value; } 
        }


        // 3. Class Constructors

        // Default constructor
        
        public Clinic()
        {
            doctorSchedules = new Dictionary<Doctor, string>(); // initialize empty dictionary
        }

        // Constructor with parameters
        public Clinic(int id, string name, int departmentId, int branchId) // Unique identifier for the clinic, Name of the clinic, ID of the department the clinic belongs to, ID of the branch the clinic is located in
        {
            this.id = id; // Unique identifier for the clinic
            this.name = name; // Name of the clinic
            this.departmentId = departmentId; // ID of the department the clinic belongs to
            this.branchId = branchId; // ID of the branch the clinic is located in
            this.doctorSchedules = new Dictionary<Doctor, string>(); // Initialize the dictionary to hold doctor schedules
        }

        // 4. Class Methods
        // Add a doctor with specific time
        public void AddDoctor(Doctor doctor, string availableTime)
        {
            if (!doctorSchedules.ContainsKey(doctor)) // Check if the doctor is already in the dictionary
                doctorSchedules.Add(doctor, availableTime); // Add the doctor and their available time to the dictionary
        }


        // Display clinic information
        public void PrintClinicInfo()
        {
            Console.WriteLine($"Clinic ID: {id}"); // Unique identifier for the clinic
            Console.WriteLine($"Name: {name}"); // Name of the clinic
            Console.WriteLine($"Department ID: {departmentId}"); // ID of the department the clinic belongs to
            Console.WriteLine($"Branch ID: {branchId}"); // ID of the branch the clinic is located in
            Console.WriteLine($"Total Doctors: {doctors.Count}"); // Total number of doctors in the clinic
        }

    }
}
