using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Utilities
{


    public static class SaveLoadingFile
    {

        // Static file names for different entities in the healthcare system
        public static string DoctorFile = "doctors.txt"; 
        public static string SuperAdminFile = "superAdmins.txt";
        public static string ClinicFile = "clinics.txt";
        public static string PatientFile = "patients.txt";
        public static string BookingFile = "Booking.txt";
        public static string BranchFile = "branches.txt";
        public static string DepartmentFile = "departments.txt";
        public static string BranchDepartmentFile = "branchDepartments.txt"; 
        public static string AdminFile = "Admin.txt";
        public static string ServiceFile = "Service.txt";

        // Method to save data to a file
        public static void SaveToFile<T>(List<T> dataList, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in dataList)
                {
                    writer.WriteLine(item.ToString()); //  override ToString
                }
            }
        }
        // Generic Load Method (Assumes T has a Parse Method or Manual Parsing is Needed)
        public static List<string> LoadFromFile(string filePath)
        {
            List<string> lines = new List<string>(); // Initialize an empty list to store lines
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        lines.Add(line); // Add each line to the list
                    }
                }
                Console.WriteLine($"📂 Data loaded from '{filePath}' successfully."); 
            }
            else
            {
                Console.WriteLine($"⚠️ File '{filePath}' does not exist."); 
            }
            return lines; 
        }
    }
}
