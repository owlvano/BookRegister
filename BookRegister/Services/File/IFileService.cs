using BookRegister.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookRegister.Services
{
    interface IFileService
    {
        public Task<IEnumerable<Book>> ReadFile(string filePath);
        public Task WriteFile(IEnumerable<Book> books, string filePath);
    }
}
