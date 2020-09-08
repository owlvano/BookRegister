using BookRegister.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace BookRegister.Services
{
    class JsonFileService : IFileService
    {
        public IEnumerable<Book> ReadFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<IEnumerable<Book>>(jsonString);
        }

        public void WriteFile(IEnumerable<Book> books, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(filePath, jsonString);
            MessageBox.Show($"Books successfully saved to file '{filePath}'!", "Success");
        }
    }
}
