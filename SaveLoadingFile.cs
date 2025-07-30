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
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in dataList)
                {
                    writer.WriteLine(item.ToString()); //  override ToString
                }
            }
        }
        // Method to load data from a file
        public static List<T> LoadFromFile<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) // Check if the file exists
                {
                    Console.WriteLine($"⚠ File not found: {filePath}"); // If file does not exist, return an empty list
                    return new List<T>(); // Return an empty list if file does not exist
                }

                string jsonData = File.ReadAllText(filePath); // Read the file content
                var dataList = JsonSerializer.Deserialize<List<T>>(jsonData); // Deserialize the JSON data into a list of type T
                Console.WriteLine($" Loaded from {filePath}");
                return dataList ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error loading file: {ex.Message}"); // Handle any exceptions that occur during loading
                return new List<T>(); // Return an empty list in case of error
            }
        }


    }
}
