using System;
using System.Collections.Generic;
using System.Linq;
using CodeLineHealthCareCenter.Utilities;
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
        public List<ClinicSpots> ClinicSpots { get; set; } = new List<ClinicSpots>();

        // List of doctors assigned to this clinic
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();



        // ========================== Constructor ==========================
        /// defualt constructor
        public Clinic()
        {
            clinicCounter++;
            ClinicId = clinicCounter;
            ClinicName = "Default Clinic";
            Location = "Default Location";
            DepartmentId = 0;
            BranchId = 0;
            FloorId = 0;
            RoomId = 0;
            Price = 0.0m; // Default price
        }
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
        public void AddClinic(string clinicName, string location, int departmentId, int branchId, int floorId, int roomId, decimal price)
        {
            // 1️⃣ Create a new clinic object
            Clinic newClinic = new Clinic(clinicName, location, departmentId, branchId, floorId, roomId, price);

            // 2️⃣ Ask if doctors should be assigned to this clinic
            Console.WriteLine("Do you want to assign doctors to this clinic? (yes/no)");
            string choice = Console.ReadLine()?.Trim().ToLower();

            if (choice == "yes")
            {
                AssignDoctorsToClinic(newClinic); // Assign doctors
            }

            // 3️⃣ Create appointment spots for this clinic
            Console.WriteLine("Enter number of appointment spots to add:");
            int spotCount = UserValidator.IntValidation("Number of Spots");

            for (int i = 0; i < spotCount; i++)
            {
                DateTime spotTime = UserValidator.DateTimeValidation(
                    $"Enter Spot #{i + 1} Date and Time (yyyy-MM-dd HH:mm)");

                // heck if this spot already exists for this clinic
                bool spotExists = newClinic.ClinicSpots.Any(s => s.Date_Time == spotTime);

                if (spotExists)
                {
                    Console.WriteLine($"⚠ Spot at {spotTime} already exists for this clinic. Please enter a different time.");
                    i--; // Decrease i so user can re-enter for the same spot number
                    continue;
                }

                // Create a new ClinicSpots object
                ClinicSpots spot = new ClinicSpots(newClinic.ClinicId, spotTime); // default IsActive = false (not booked)

                // Add the new spot to the clinic's spot list
                newClinic.ClinicSpots.Add(spot);

                Console.WriteLine($" Spot #{i + 1} added for {spotTime}");
            }

            // 4️⃣ Show status of added spots
            if (newClinic.ClinicSpots.Count == 0)
            {
                Console.WriteLine("No appointment spots added.");
            }
            else
            {
                Console.WriteLine($"{newClinic.ClinicSpots.Count} appointment spots added successfully.");
            }

            // 5️⃣ Add clinic to the static list (ONLY ONCE)
            Clinics.Add(newClinic);

            Console.WriteLine($"Clinic '{clinicName}' added successfully with ID {newClinic.ClinicId}");
        }




        /// <summary>
        /// Displays all clinics.
        /// </summary>
        public void GetClinicsByBranchAndDepartment()
        {
            // Ask the user to enter Branch ID
            int branchId = UserData.EnterBranchId(Branch.branches);

            // Ask the user to enter Department ID
            int departmentId = UserData.EnterDepartmentId(BranchDepartment.Departments);

            // Check if there are any clinics
            if (!Clinics.Any())
            {
                Console.WriteLine("No clinics available.");
                return;
            }

            // Filter clinics based on Branch ID and Department ID
            var filteredClinics = Clinics
                .Where(c => c.BranchId == branchId && c.DepartmentId == departmentId)
                .ToList();

            // Check if any matching clinics exist
            if (filteredClinics.Count == 0)
            {
                Console.WriteLine($"No clinics found for Branch ID {branchId} and Department ID {departmentId}.");
                return;
            }

            // Display clinic details
            Console.WriteLine($"Clinics in Branch ID {branchId} and Department ID {departmentId}:");
            foreach (var clinic in filteredClinics)
            {
                clinic.ViewClinicInfo(); // Show clinic info using existing method
            }
        }


        // Get clinic by ID
        public void GetClinic(int clinicId)
        {
            // Find clinic by its ID
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);

            if (clinic == null)
            {
                Console.WriteLine($"⚠ Clinic with ID {clinicId} not found.");
                return;
            }

            // Display clinic details using updated ViewClinicInfo()
            Console.WriteLine($"Clinic found with ID {clinicId}:");
            clinic.ViewClinicInfo();
        }

        // Get clinic by Name
        public void GetClinic(string clinicName)
        {
            // Find clinic by its Name (case-insensitive)
            var clinic = Clinics.FirstOrDefault(
                c => c.ClinicName.Equals(clinicName, StringComparison.OrdinalIgnoreCase));

            if (clinic == null)
            {
                Console.WriteLine($"Clinic with name '{clinicName}' not found.");
                return;
            }

            // Display clinic details using updated ViewClinicInfo()
            Console.WriteLine($"Clinic found with name '{clinicName}':");
            clinic.ViewClinicInfo();
        }


        //  Get clinic name by ID
        public void GetClinicName(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine($"Clinic with ID {clinicId} not found.");
                return;
            }

            Console.WriteLine($" Clinic Name: {clinic.ClinicName}");
        }

        // Get all clinics by Branch Name
        public void GetClinicByBranchName(string branchName)
        {
            int BranchId = 0; // Initialize BranchId to 0
            // for loop get branch id through branch name 
            for (int i = 0; i < Branch.branches.Count; i++)
            {
                if (Branch.branches[i].BranchName.Equals(branchName, StringComparison.OrdinalIgnoreCase))
                {
                    BranchId = Branch.branches[i].BranchId;
                    break;
                }
            }


            var filteredClinics = Clinics
                .Where(c => c.BranchId== BranchId)
                .ToList();

            if (!filteredClinics.Any())
            {
                Console.WriteLine($" No clinics found for branch '{branchName}'.");
                return;
            }

            Console.WriteLine($" Clinics under branch '{branchName}':");
            foreach (var clinic in filteredClinics)
                clinic.ViewClinicInfo();
        }

        // Get all clinics by Department ID
        public void GetClinicByDepartmentId(int departmentId)
        {
            var filteredClinics = Clinics.Where(c => c.DepartmentId == departmentId).ToList();

            if (!filteredClinics.Any())
            {
                Console.WriteLine($"No clinics found for Department ID {departmentId}.");
                return;
            }

            Console.WriteLine($"Clinics under Department ID {departmentId}:");
            foreach (var clinic in filteredClinics)
                clinic.ViewClinicInfo();
        }

        // Get clinic price
        public void GetPrice(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine($"Clinic with ID {clinicId} not found.");
                return;
            }

            Console.WriteLine($"Clinic Price: {clinic.Price:C}");
        }

        // Change clinic status (open/closed)
        public void SetClinicStatus(int clinicId, bool isActive)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine($"Clinic with ID {clinicId} not found.");
                return;
            }

            clinic.clinicStatus = isActive;
            Console.WriteLine($"Clinic status updated to {(isActive ? "Open " : "Closed")}");
        }

        // Update clinic details
        public void UpdateClinicDetails(int clinicId, string clinicName, string location, decimal price)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine($" Clinic with ID {clinicId} not found.");
                return;
            }

            // Update fields (keep old values if parameters are empty/default)
            if (!string.IsNullOrWhiteSpace(clinicName))
                clinic.ClinicName = clinicName;

            if (!string.IsNullOrWhiteSpace(location))
                clinic.Location = location;

            if (price > 0)
                clinic.Price = price;

            Console.WriteLine("Clinic details updated successfully.");
        }

        // Delete clinic
        public void DeleteClinic(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine($"Clinic with ID {clinicId} not found.");
                return;
            }

            Clinics.Remove(clinic);
            Console.WriteLine($"Clinic '{clinic.ClinicName}' deleted successfully.");
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
            // 1️⃣ Check if there are any doctors available
            if (Doctor.doctors.Count == 0)
            {
                Console.WriteLine("No doctors available to assign.");
                return;
            }

            // 2️⃣ Show available doctors
            Console.WriteLine("\n=== Available Doctors ===");
            foreach (var doc in Doctor.doctors)
            {
                Console.WriteLine($"{doc.UserId} - {doc.UserName} | {doc.Specialty} | Email: {doc.Email}");
            }

            // 3️⃣ Ask user to enter doctor ID
            int doctorId = UserValidator.IntValidation("Enter Doctor ID to assign");

            // 4️⃣ Find doctor from the main doctor list
            var doctor = Doctor.doctors.FirstOrDefault(d => d.UserId == doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            // 5️⃣ Check if the doctor is already assigned to this clinic
            if (clinic.Doctors.Any(d => d.UserId == doctor.UserId))
            {
                Console.WriteLine($"Doctor {doctor.UserName} is already assigned to this clinic.");
                return;
            }

            // 6️⃣ Create a new doctor object specific to this clinic
            Doctor assignedDoctor = new Doctor(
                doctor.UserName,
                doctor.Email,
                doctor.Password,
                doctor.NationalID,
                doctor.PhoneNumber,
                doctor.Gender,
                doctor.Specialty,
                clinic.BranchId,
                clinic.DepartmentId
            );

            // 7️⃣ Add the doctor to the clinic
            clinic.Doctors.Add(assignedDoctor);

            Console.WriteLine($"Doctor {doctor.UserName} has been assigned to Clinic '{clinic.ClinicName}'.");
        }

        // Get All Doctors By ClinicId
        public void GetAllDoctorsByClinicId(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine($"Clinic with ID {clinicId} not found.");
                return;
            }
            if (clinic.Doctors.Count == 0)
            {
                Console.WriteLine($"No doctors assigned to Clinic '{clinic.ClinicName}'.");
                return;
            }
            Console.WriteLine($"Doctors in Clinic '{clinic.ClinicName}':");
            foreach (var doctor in clinic.Doctors)
            {
                Console.WriteLine($"- {doctor.UserName} ({doctor.Specialty})");
            }
        }


    }
}
