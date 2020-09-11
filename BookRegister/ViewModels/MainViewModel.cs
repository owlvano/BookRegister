using BookRegister.Models;
using BookRegister.Services;
using BookRegister.Views;
using BookRegister.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;

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

            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            Task.Run(ReadBooksAsync);
        }

        #region Properties
        private bool _isBusy = false;
        public bool IsBusy {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private string _busyMessage;
        public string BusyMessage
        {
            get => _busyMessage;
            set
            {
                _busyMessage = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Book> Books
        {
            get => _bookService.GetBooks();
            set
            {
                _bookService.SetBooks(value);
                OnPropertyChanged();
            }
        }


        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
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
            get => _addBookCommand ?? (_addBookCommand = new RelayCommand(AddBook));
        }

        private RelayCommand _editBookCommand;
        public ICommand EditBookCommand
        {
            get => _editBookCommand ?? (_editBookCommand = new RelayCommand(EditBook, IsBookSelected));
        }

        private RelayCommand _removeBookCommand;
        public ICommand RemoveBookCommand
        {
            get => _removeBookCommand ?? (_removeBookCommand = new RelayCommand(RemoveBook, IsBookSelected));
        }

        private RelayCommand _saveBooksCommand;
        public ICommand SaveBooksCommand
        {
            get => _saveBooksCommand ?? (_saveBooksCommand = new RelayCommand(SaveBooksAsync, IsBookListNotEmpty));
        }
        #endregion

        #region Private Methods
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

        private async void ReadBooksAsync()
        {
            IsBusy = true;
            BusyMessage = $"Reading a file from '{BOOKS_FILE_NAME}'...";

            try
            {
                var bookList = await _fileService.ReadFile(BOOKS_FILE_NAME);
                Books = new ObservableCollection<Book>(bookList);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"'{BOOKS_FILE_NAME}' file was not found. Starting with an empty list!", "Error");
                return;
            }
            finally
            {
                IsBusy = false;
                BusyMessage = "";
            }
        }

        private async void SaveBooksAsync()
        {
            IsBusy = true;
            BusyMessage = $"Writing to a '{BOOKS_FILE_NAME}' file...";

            await _fileService.WriteFile(Books, BOOKS_FILE_NAME);

            IsBusy = false;
            BusyMessage = "";

            MessageBox.Show($"Books successfully saved to file '{BOOKS_FILE_NAME}'!", "Success");
        }

        private bool IsBookSelected() => SelectedBook != null;
        private bool IsBookListNotEmpty() => Books.Count > 0;
        #endregion
    }
}
