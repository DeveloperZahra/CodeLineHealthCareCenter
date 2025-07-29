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

        // Dictionary<doctorId, availableTime>
        public Dictionary<int, string> doctorSchedules;


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
        public Dictionary<int, string> DoctorSchedules // Dictionary to hold doctor schedules with doctor ID as key and available time as value
        {
            get { return doctorSchedules; }
            set { doctorSchedules = value; }
        }


        // 3. Class Constructors

        // Default constructor

        public Clinic()
        {
            doctorSchedules = new Dictionary<int, string>(); // initialize empty dictionary
        }

        // Constructor with parameters
        public Clinic(int id, string name, int departmentId, int branchId) // Unique identifier for the clinic, Name of the clinic, ID of the department the clinic belongs to, ID of the branch the clinic is located in
        {
            this.id = id; // Unique identifier for the clinic
            this.name = name; // Name of the clinic
            this.departmentId = departmentId; // ID of the department the clinic belongs to
            this.branchId = branchId; // ID of the branch the clinic is located in
            this.doctorSchedules = new Dictionary<int, string>(); // initialize empty dictionary
        }

        // 4. Class Methods
       
         //update a doctor's available time
        public void AddOrUpdateDoctorSchedule(Doctor doctor, string availableTime)
        {
            if (doctorSchedules.ContainsKey(doctor))
                doctorSchedules[doctor] = availableTime; // update time if doctor exists
            else
                doctorSchedules.Add(doctor, availableTime); // add new doctor and time
        }


        // Display clinic and doctor schedule info
        public void PrintClinicInfo()
        {
            Console.WriteLine($"Clinic ID: {id}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Department ID: {departmentId}");
            Console.WriteLine($"Branch ID: {branchId}");
            Console.WriteLine("Doctors and Available Times:");

            if (doctorSchedules.Count == 0) // no doctors assigned
            {
                Console.WriteLine("No doctors assigned to this clinic yet."); 
            }
            else
            {
                foreach (var entry in doctorSchedules) 
                {
                    Console.WriteLine($"- Dr. {entry.Key.FullName} | Available: {entry.Value}"); 
                }
            }
        }

    }
}
