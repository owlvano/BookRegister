using BookRegister.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BookRegister.Services
{
    class JsonFileService : IFileService
    {
        public IEnumerable<Book> ReadFile(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<IEnumerable<Book>>(jsonString);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public void WriteFile(IEnumerable<Book> books, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
