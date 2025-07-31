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
    }
}
