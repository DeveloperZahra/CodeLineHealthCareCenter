using System;
using System.Collections.Generic;
using System.Linq;
using HospitalSystemTeamTask.Services;

namespace CodeLineHealthCareCenter.Models
{
    public class Clinic : IClinicService
    {

        // Private static counter to generate unique IDs for clinics
        private static int clinicCounter = 0;

        // Private field to store the status of the clinic (open or closed)
        private bool clinicStatus = true;

        // Private fields for location and price
        private string location;
        private decimal price;

        // Property for unique clinic ID (read-only)
        public int ClinicId { get; private set; }

        // Property for clinic name
        public string ClinicName { get; set; }

        // Property for department ID that the clinic belongs to
        public int DepartmentId { get; set; }

        // Property for branch ID that the clinic belongs to
        public int BranchId { get; set; }

        // Property for floor ID where the clinic is located
        public int FloorId { get; set; }

        // Property for room ID where the clinic is located
        public int RoomId { get; set; }

        /// <summary>
        ///  Static list to store all clinics created in the system.
        /// </summary>
        
        // Property for the clinic location
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        // Property for the price of clinic services
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        // Property to get the current status of the clinic (open or closed)
        public bool ClinicStatus
        {
            get { return clinicStatus; }
        }


        //===================================== Lists =====================================
        ///  wamt Clinics +Doctors + ClinicSpots 
        // Static list to store all clinics created in the system
        public static List<Clinic> Clinics = new List<Clinic>();

        // List of available appointment times for the clinic
        public List<DateTime> ClinicSpots { get; set; } = new List<DateTime>();


        // Constructor to create a new clinic with required details
        public Clinic(string clinicName, string location, int departmentId, int branchId, int floorId, int roomId, decimal price)
        {
            clinicCounter++; // Increment the counter to assign a new unique ID
            ClinicId = clinicCounter; // Assign the unique ID to the clinic
            ClinicName = clinicName; // Set clinic name
            Location = location; // Set clinic location
            DepartmentId = departmentId; // Set department ID
            BranchId = branchId; // Set branch ID
            FloorId = floorId; // Set floor ID
            RoomId = roomId; // Set room ID
            Price = price; // Set clinic price
        }

        // Method to add a new clinic to the system
        public void AddClinic(string clinicName, string location)
        {
            clinicCounter++;
            Clinic newClinic = new Clinic(clinicName, location, 0, 0, 0, 0, 0);
            Clinics.Add(newClinic);
            Console.WriteLine("Clinic added successfully with ID " + newClinic.ClinicId);
        }
        // Method to get and display all clinics
        public void GetAllClinics()
        {
            if (!Clinics.Any())
            {
                Console.WriteLine("No clinics available.");
                return;
            }

            foreach (var clinic in Clinics)
            {
                clinic.ViewClinicInfo();
            }
        }
        // Method to get a clinic by its unique ID
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

        // Method to get a clinic by branch ID and department ID
        public void GetClinicByBranchDep(int branchId, int departmentId)
        {
            var filteredClinics = Clinics.Where(c => c.BranchId == branchId && c.DepartmentId == departmentId).ToList();
            if (!filteredClinics.Any())
            {
                Console.WriteLine("No clinics found for the given branch and department.");
                return;
            }
            foreach (var clinic in filteredClinics)
            {
                clinic.ViewClinicInfo();
            }
        }

        // Method to get a clinic by its name
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
        // Method to get the name of a clinic by its ID
        public void GetClinicName(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            Console.WriteLine("Clinic Name: " + clinic.ClinicName);
        }
        // Method to get all clinics by branch name 
        public void GetClinicByBranchName(string branchName)
        {
            Console.WriteLine("Branch name-based search requires branch details integration.");
        }
        // Method to get all clinics by department ID
        public void GetClinicByDepartmentId(int departmentId)
        {
            var filteredClinics = Clinics.Where(c => c.DepartmentId == departmentId).ToList();
            if (!filteredClinics.Any())
            {
                Console.WriteLine("No clinics found for the given department.");
                return;
            }
            foreach (var clinic in filteredClinics)
            {
                clinic.ViewClinicInfo();
            }
        }

        // Method to get the price of a clinic by its ID
        public void GetPrice(int clinicId)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            Console.WriteLine("Clinic Price: " + clinic.Price);
        }
        // Method to set the status (open or closed) of a clinic by its ID
        public void SetClinicStatus(int clinicId, bool isActive)
        {
            var clinic = Clinics.FirstOrDefault(c => c.ClinicId == clinicId);
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }
            clinic.clinicStatus = isActive;
            Console.WriteLine("Clinic status updated successfully.");
        }
        // Method to update the details of a clinic
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
            Console.WriteLine("Clinic details updated successfully.");
        }
        // Method to delete a clinic by its ID
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

       




















    }
}
