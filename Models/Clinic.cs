using System;
using System.Collections.Generic;
using System.Linq;
using HospitalSystemTeamTask.Services;

namespace CodeLineHealthCareCenter.Models
{
    public class Clinic : IClinicService
    {
        // Static counter to generate unique clinic IDs
        private static int clinicCounter = 0;

        // Private field for clinic status
        private bool clinicStatus = true;

        // Private fields for location and price
        private string location;
        private decimal price;

        // ========================== Properties ==========================
        public int ClinicId { get; private set; } // Unique ID
        public string ClinicName { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }

        public string Location { get => location; set => location = value; }
        public decimal Price { get => price; set => price = value; }
        public bool ClinicStatus => clinicStatus;

        // Static list to store all clinics
        public static List<Clinic> Clinics = new List<Clinic>();

        // List of available time slots
        public List<DateTime> ClinicSpots { get; set; } = new List<DateTime>();

        // List of doctors assigned to this clinic
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();

        // ========================== Constructor ==========================
        public Clinic(string clinicName, string location, int departmentId, int branchId, int floorId, int roomId, decimal price)
        {
            clinicCounter++;
            ClinicId = clinicCounter;
            ClinicName = clinicName;
            Location = location;
            DepartmentId = departmentId;
            BranchId = branchId;
            FloorId = floorId;
            RoomId = roomId;
            Price = price;
        }

        // ========================== Interface Methods ==========================

        /// <summary>
        /// Adds a new clinic and optionally assigns doctors to it.
        /// </summary>
        public void AddClinic(string clinicName, string location)
        {
            // 1️⃣ Create a new clinic object
            Clinic newClinic = new Clinic(clinicName, location, 0, 0, 0, 0, 0);

            // 2️⃣ Optionally assign doctors to this clinic
            Console.WriteLine("Do you want to assign doctors to this clinic? (yes/no)");
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "yes")
            {
                AssignDoctorsToClinic(newClinic);
            }

            // 3️⃣ Add clinic to the static list
            Clinics.Add(newClinic);
            Console.WriteLine($"Clinic '{newClinic.ClinicName}' added successfully with ID {newClinic.ClinicId}");
        }

        /// <summary>
        /// Displays all clinics.
        /// </summary>
        public void GetAllClinics()
        {
            if (!Clinics.Any())
            {
                Console.WriteLine("No clinics available.");
                return;
            }

            foreach (var clinic in Clinics)
                clinic.ViewClinicInfo();
        }

        public void GetClinicById(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            clinic.ViewClinicInfo();
        }

        public void GetClinicByBranchDep(int branchId, int departmentId)
        {
            var filteredClinics = Clinics.Where(c => c.BranchId == branchId && c.DepartmentId == departmentId).ToList();
            if (!filteredClinics.Any())
            {
                Console.WriteLine("No clinics found for the given branch and department.");
                return;
            }
            foreach (var clinic in filteredClinics)
                clinic.ViewClinicInfo();
        }

        public void GetClinicByName(string clinicName)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicName.Equals(clinicName, StringComparison.OrdinalIgnoreCase));
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            clinic.ViewClinicInfo();
        }

        public void GetClinicName(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            Console.WriteLine($"Clinic Name: {clinic.ClinicName}");
        }

        public void GetClinicByBranchName(string branchName)
        {
            Console.WriteLine("This method requires branch details integration.");
        }

        public void GetClinicByDepartmentId(int departmentId)
        {
            var filteredClinics = Clinics.Where(c => c.DepartmentId == departmentId).ToList();
            if (!filteredClinics.Any())
            {
                Console.WriteLine("No clinics found for this department.");
                return;
            }

            foreach (var clinic in filteredClinics)
                clinic.ViewClinicInfo();
        }

        public void GetPrice(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            Console.WriteLine($"Clinic Price: {clinic.Price}");
        }

        public void SetClinicStatus(int clinicId, bool isActive)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            clinic.clinicStatus = isActive;
            Console.WriteLine("Clinic status updated.");
        }

        public void UpdateClinicDetails(int clinicId, string clinicName, string location, decimal price)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }

            clinic.ClinicName = clinicName;
            clinic.Location = location;
            clinic.Price = price;
            Console.WriteLine("Clinic details updated.");
        }

        public void DeleteClinic(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            Clinics.Remove(clinic);
            Console.WriteLine("Clinic deleted successfully.");
        }

        /// <summary>
        /// Displays clinic details including assigned doctors.
        /// </summary>
        public void ViewClinicInfo()
        {
            Console.WriteLine($"\nClinic ID: {ClinicId}, Name: {ClinicName}, Location: {Location}, Price: {Price}, Status: {(ClinicStatus ? "Open" : "Closed")}");
            Console.WriteLine($"Department: {DepartmentId}, Branch: {BranchId}");
            Console.WriteLine($"Doctors Assigned: {Doctors.Count}");

            foreach (var doc in Doctors)
                Console.WriteLine($" - {doc.UserName} ({doc.Specialty})");

            Console.WriteLine($"Available Appointments: {ClinicSpots.Count}");
        }

        // ========================== New Method ==========================
        /// <summary>
        /// Allows assigning existing doctors to a clinic.
        /// </summary>
        private void AssignDoctorsToClinic(Clinic clinic)
        {
            if (Doctor.doctors.Count == 0)
            {
                Console.WriteLine("No doctors available to assign.");
                return;
            }

            Console.WriteLine("Available Doctors:");
            foreach (var doc in Doctor.doctors)
                Console.WriteLine($"{doc.UserId} - {doc.UserName} ({doc.Specialty})");

            Console.WriteLine("Enter Doctor IDs to assign (comma separated):");
            string input = Console.ReadLine();
            var ids = input.Split(',').Select(id => id.Trim()).ToList();

            foreach (var id in ids)
            {
                var doctor = Doctor.doctors.FirstOrDefault(d => d.UserId == id);
                if (doctor != null)
                {
                    clinic.Doctors.Add(doctor);
                    Console.WriteLine($"Doctor {doctor.UserName} assigned to clinic.");
                }
                else
                {
                    Console.WriteLine($"Doctor with ID {id} not found.");
                }
            }
        }
    }
}
