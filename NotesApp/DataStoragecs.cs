using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    internal class DataStorages
    {
        public static async Task SaveToJsonFile<T>(T data, string filePath)
        {
            try
            {
                // 1. Serialize Object in JSON-String
                string jsonString = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                // 2. Write in Data
                await File.WriteAllTextAsync(filePath, jsonString);
                Console.WriteLine($"Successfully stored Data in: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Storing Data Failure: {ex.Message}");
            }

        }
        public static async Task<T?> LoadFromJsonFile<T>(string filePath) where T : class
        {
            {
                if (!File.Exists(filePath)) { return null; }
                try
                {
                    string jsonString = await File.ReadAllTextAsync(filePath);
                    Console.WriteLine($"Successfully red Data in: {filePath}");
                    return JsonSerializer.Deserialize<T>(jsonString);   
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Reading Data Failure: {ex.Message}");
                    return null;
                }
            }
        }
    }
}