using BookRegister.Models;
using BookRegister.Services;
using BookRegister.Views;
using BookRegister.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

namespace BookRegister.ViewModels
{
    class MainViewModel: ViewModelBase
    {
        const string BOOKS_FILE_NAME = "Books.json";

        private IFileService _fileService;
        private IBookService _bookService;

        public MainViewModel(IFileService fileService, IBookService bookService)
        {
            _fileService = fileService;
            _bookService = bookService;

            IEnumerable<Book> books = fileService.ReadFile(BOOKS_FILE_NAME);
            _bookService.LoadBooks(books);

            Books = _bookService.GetBooks();
        }

        #region Properties
        public ObservableCollection<Book> Books { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        private RelayCommand _addBookCommand;
        public ICommand AddBookCommand
        {
            get
            {
                return _addBookCommand ?? (_addBookCommand = new RelayCommand(AddBook));
            }
        }

        private RelayCommand _editBookCommand;
        public ICommand EditBookCommand
        {
            get
            {
                return _editBookCommand ?? (_editBookCommand = new RelayCommand(EditBook, IsBookSelected));
            }
        }

        private RelayCommand _removeBookCommand;
        public ICommand RemoveBookCommand
        {
            get
            {
                return _removeBookCommand ?? (_removeBookCommand = new RelayCommand(RemoveBook, IsBookSelected));
            }
        }

        private RelayCommand _saveBooksCommand;
        public ICommand SaveBooksCommand
        {
            get
            {
                return _saveBooksCommand ?? (_saveBooksCommand = new RelayCommand(SaveBooks, IsBookListNotEmpty));
            }
        }
        #endregion

        #region Helper Methods
        private void AddBook()
        {
            Book tempBook = new Book() { };
            EditBookViewModel editViewModel = new EditBookViewModel("New book", tempBook);
            EditBookView editView = new EditBookView() { DataContext = editViewModel };
            if (editView.ShowDialog() == true)
            {
                _bookService.AddBook(tempBook);
            }
        }

        private void EditBook()
        {
            Book tempBook = SelectedBook.DeepCopy();
            EditBookViewModel editViewModel = new EditBookViewModel("Edit a book", tempBook);
            EditBookView editView = new EditBookView() { DataContext = editViewModel };
            if (editView.ShowDialog() == true)
            {
                _bookService.UpdateBook(SelectedBook.Id, tempBook);
            }
        }

        private void RemoveBook()
        {
            RemoveBookConfirmationView confirmationView = new RemoveBookConfirmationView();
            if (confirmationView.ShowDialog() == true)
            {
                _bookService.RemoveBook(SelectedBook.Id);
            }
        }

        private void SaveBooks()
        {
            _fileService.WriteFile(Books, BOOKS_FILE_NAME);
        }

        private bool IsBookSelected() => SelectedBook != null;
        private bool IsBookListNotEmpty() => Books.Count > 0;
        #endregion
    }
}
