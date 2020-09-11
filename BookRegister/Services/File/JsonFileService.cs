using BookRegister.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookRegister.Services
{
    class JsonFileService : IFileService
    {
        public async Task<IEnumerable<Book>> ReadFile(string filePath)
        {
            try
            {
                await Task.Delay(3000);
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<IEnumerable<Book>>(jsonString);
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        public async Task WriteFile(IEnumerable<Book> books, string filePath)
        {
            await Task.Delay(3000);
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
