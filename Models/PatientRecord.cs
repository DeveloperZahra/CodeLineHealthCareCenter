using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodelineHealthCareCenter.Services;
using CodeLineHealthCareCenter;

namespace CodelineHealthCareCenter.Models
{
    class PatientRecord : IPatientRecordService
    {
        // 1. ===== Class Fields =====
        public int PatientRecordId;  // Unique ID for the record
        public int PatientId;        // ID of the patient
        public int ClinicId;         // ID of the clinic
        public DateTime DateCreated; // Date when record was created

        public List<Service> Services = new List<Service>(); // This list stores only the services that a particular patient used in that record.
        public double TotalCost;     // Total cost for all services
        public string DoctorNote;    // Notes provided by the doctor

        public static int PatientRecordCount = 0;               // Counter for record IDs
        public static List<PatientRecord> Records = new();      // Static list to store all records

        // 2. ===== Properties =====
        public static int RecordCount => PatientRecordCount; // Read-only property for count

        // 3. ===== Constructor =====
        public PatientRecord(int patientId, int clinicId, string doctorNote, List<Service> services)
        {
            PatientRecordCount++;
            PatientRecordId = PatientRecordCount;
            PatientId = patientId;
            ClinicId = clinicId;
            DoctorNote = doctorNote;
            Services = services;
            TotalCost = (double)services.Sum(s => s.Price);// Automatically calculate cost
            DateCreated = DateTime.Now;
        }

        // 4. ===== Instance Methods (Implementing IPatientRecordService) =====

        // Adds a new patient record
        public void AddPatientRecord(int patientId, string recordDetails)
        {
            int clinicId = UserValidator.IntValidation("Enter Clinic ID");

            // Ask user to add services
            Console.Write("Enter number of services to add: ");
            int count = UserValidator.IntValidation("Service Count");

            List<Service> selectedServices = new List<Service>();
            for (int i = 0; i < count; i++)
            {
                int serviceId = UserValidator.IntValidation($"Service ID #{i + 1}");
                var service = Service.Services.FirstOrDefault(s => s.ServiceId == serviceId);

                if (service == null)
                {
                    Console.WriteLine("Invalid service ID. Skipping...");
                    continue;
                }

                selectedServices.Add(service);
            }

            // Create and store record
            var record = new PatientRecord(patientId, clinicId, recordDetails, selectedServices);
            Records.Add(record);

            Console.WriteLine($"Patient record added successfully with ID: {record.PatientRecordId}");
        }

        // Updates a doctor's note for an existing record
        public void UpdatePatientRecord(int recordId, string newDetails)
        {
            var record = Records.FirstOrDefault(r => r.PatientRecordId == recordId);
            if (record == null)
            {
                Console.WriteLine("Record not found.");
                return;
            }

            record.DoctorNote = newDetails;
            Console.WriteLine("Doctor note updated successfully.");
        }

        // Deletes a patient record
        public void DeletePatientRecord(int recordId)
        {
            var record = Records.FirstOrDefault(r => r.PatientRecordId == recordId);
            if (record == null)
            {
                Console.WriteLine("Record not found.");
                return;
            }

            Records.Remove(record);
            Console.WriteLine("Patient record deleted successfully.");
        }

        // Gets a specific patient record by ID
        public void GetPatientRecordById(int recordId)
        {
            var record = Records.FirstOrDefault(r => r.PatientRecordId == recordId);
            if (record == null)
            {
                Console.WriteLine("Record not found.");
                return;
            }

            record.ViewRecordDetails();
        }

        // Gets all patient records
        public void GetAllPatientRecords()
        {
            if (Records.Count == 0)
            {
                Console.WriteLine("No patient records found.");
                return;
            }

            foreach (var record in Records)
                record.ViewRecordDetails();
        }

        // Gets all records for a specific patient
        public void GetRecordsByPatientId(int patientId)
        {
            var results = Records.Where(r => r.PatientId == patientId).ToList();
            if (results.Count == 0)
            {
                Console.WriteLine("No records found for this patient.");
                return;
            }

            foreach (var r in results)
                r.ViewRecordDetails();
        }

        // Gets all records for a clinic on a specific date
        public void GetRecordsByClinicIdAndDate(int clinicId, DateTime date)
        {
            var results = Records
                .Where(r => r.ClinicId == clinicId && r.DateCreated.Date == date.Date)
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No records found for this clinic on the given date.");
                return;
            }

            foreach (var r in results)
                r.ViewRecordDetails();
        }

        // 5. ===== Helper Methods =====

        // Displays record details
        public void ViewRecordDetails()
        {
            Console.WriteLine("\n=== PATIENT RECORD DETAILS ===");
            Console.WriteLine($"Record ID: {PatientRecordId}");
            Console.WriteLine($"Patient ID: {PatientId}, Clinic ID: {ClinicId}");
            Console.WriteLine($"Date Created: {DateCreated}");
            Console.WriteLine($"Total Cost: ${TotalCost}");
            Console.WriteLine($"Doctor Note: {DoctorNote}");
            Console.WriteLine("Services:");
            foreach (var s in Services)
                Console.WriteLine($" - {s.ServiceName} (${s.Price})");
        }

        // Saves all records to a file
        public static void SaveToFile(string filePath)
        {
            using StreamWriter writer = new(filePath);
            foreach (var record in Records)
            {
                string serviceIds = string.Join(",", record.Services.Select(s => s.ServiceId));
                writer.WriteLine($"{record.PatientRecordId}|{record.PatientId}|{record.ClinicId}|{record.DateCreated:O}|{record.TotalCost}|{record.DoctorNote}|{serviceIds}");
            }
        }

        // Loads records from a file
        public static void LoadFromFile(string filePath)
        {
            Records.Clear();
            PatientRecordCount = 0;

            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length < 7) continue;

                int recordId = int.Parse(parts[0]);
                int patientId = int.Parse(parts[1]);
                int clinicId = int.Parse(parts[2]);
                DateTime dateCreated = DateTime.Parse(parts[3]);
                double totalCost = double.Parse(parts[4]);
                string doctorNote = parts[5];

                var serviceIds = parts[6].Split(',').Select(int.Parse).ToList();
                var selectedServices = Service.Services.Where(s => serviceIds.Contains(s.ServiceId)).ToList();

                var record = new PatientRecord(patientId, clinicId, doctorNote, selectedServices)
                {
                    PatientRecordId = recordId,
                    DateCreated = dateCreated,
                    TotalCost = totalCost
                };

                Records.Add(record);
                if (record.PatientRecordId > PatientRecordCount)
                    PatientRecordCount = record.PatientRecordId;
            }
        }
    }
}
