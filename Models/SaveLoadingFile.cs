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
                        lines.Add(line);
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
