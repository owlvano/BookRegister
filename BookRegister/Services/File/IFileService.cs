using BookRegister.Models;
using System.Collections.Generic;


namespace BookRegister.Services
{
    interface IFileService
    {
        public IEnumerable<Book> ReadFile(string filePath);
        public void WriteFile(IEnumerable<Book> books, string filePath);
    }
}
