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
        // Method to save data to a file
        public static void SaveToFile<T>(List<T> dataList, string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(dataList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine($"✅ Saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving file: {ex.Message}");
            }
        }

        // Method to load data from a file
        public static List<T> LoadFromFile<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) // Check if the file exists
                {
                    Console.WriteLine($"⚠️ File not found: {filePath}");
                    return new List<T>();
                }

                string jsonData = File.ReadAllText(filePath); // Read the file content
                var dataList = JsonSerializer.Deserialize<List<T>>(jsonData); // Deserialize the JSON data into a list of type T
                Console.WriteLine($"✅ Loaded from {filePath}");
                return dataList ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading file: {ex.Message}"); // Handle any exceptions that occur during loading
                return new List<T>();
            }
        }


    }
}
