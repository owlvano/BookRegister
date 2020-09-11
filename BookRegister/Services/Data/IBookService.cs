using BookRegister.Models;
using System.Collections.ObjectModel;

namespace BookRegister.Services
{
    interface IBookService
    {
        ObservableCollection<Book> GetBooks();
        void LoadBooks(ObservableCollection<Book> books);
        void AddBook(Book newBook);
        void UpdateBook(int bookId, Book newBook);
        void RemoveBook(int bookId);
        Book SelectBook(int bookId);
    }
}
