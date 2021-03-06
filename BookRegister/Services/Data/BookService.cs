﻿using BookRegister.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace BookRegister.Services
{
    class BookService : IBookService
    {
        private ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public void SetBooks(ObservableCollection<Book> books)
        {
            _books = books;
        }

        public ObservableCollection<Book> GetBooks()
        {
            return _books;
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void RemoveBook(int bookId)
        {
            Book book = SelectBook(bookId);
            _books.Remove(book);
        }

        public void UpdateBook(int bookId, Book newBook)
        {
            Book oldBook = SelectBook(bookId);
            int index = _books.IndexOf(oldBook);
            if (index != -1)
            {
                _books[index] = newBook;
            }
            
        }

        public Book SelectBook(int bookId) => _books.Where(b => b.Id == bookId).First();
    }
}
