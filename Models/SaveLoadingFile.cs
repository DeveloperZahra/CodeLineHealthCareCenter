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
        public static List<string> LoadFromFile(string filePath) 
        {
            List<string> lines = new List<string>(); 

            if (File.Exists(filePath)) // Check if the file exists
            {
                lines.AddRange(File.ReadAllLines(filePath)); 
            }

            return lines;
        }
    }
}