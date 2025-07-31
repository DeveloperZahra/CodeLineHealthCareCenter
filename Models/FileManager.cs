using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CodeLineHealthCareCenter.Utilities
{
    public static class FileManager
    {
        // Save any list of objects to a file in JSON format
        public static void SaveDataToFile<T>(List<T> data, string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine($"Data saved successfully to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        // Load data from a file and return as a List<T>
        public static List<T> LoadDataFromFile<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}. Returning empty list.");
                    return new List<T>();
                }

                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return new List<T>();
            }
        }

        // Save all data to their respective files
        public static void SaveAllData()
        {
            SaveDataToFile(Patient.patients, "patients.json");
            SaveDataToFile(Doctor.doctors, "doctors.json");
            SaveDataToFile(SuperAdmin.SuperAdmins, "superadmins.json");
            SaveDataToFile(Admin.Admins, "admins.json");
            SaveDataToFile(Branch.branches, "branches.json");
            SaveDataToFile(BranchDepartment.Departments, "departments.json");
            SaveDataToFile(BranchDepartment.branchDepartments, "branchdepartments.json");
            SaveDataToFile(Clinic.Clinics, "clinics.json");
            SaveDataToFile(Booking.Bookings, "bookings.json");
            SaveDataToFile(Service.Services, "services.json");

            Console.WriteLine("All data saved successfully.");
        }
        // Load all data from their respective files
        public static void LoadAllData()
        {
            Patient.patients = LoadDataFromFile<Patient>("patients.json");
            Doctor.doctors = LoadDataFromFile<Doctor>("doctors.json");
            SuperAdmin.SuperAdmins = LoadDataFromFile<SuperAdmin>("superadmins.json");
            Admin.Admins = LoadDataFromFile<Admin>("admins.json");
            Branch.branches = LoadDataFromFile<Branch>("branches.json");
            BranchDepartment.Departments = LoadDataFromFile<Department>("departments.json");
            BranchDepartment.branchDepartments = LoadDataFromFile<BranchDepartment>("branchdepartments.json");
            Clinic.Clinics = LoadDataFromFile<Clinic>("clinics.json");
            Booking.Bookings = LoadDataFromFile<Booking>("bookings.json");
            Service.Services = LoadDataFromFile<Service>("services.json");

            Console.WriteLine("All data loaded successfully.");
        }
    }
}
