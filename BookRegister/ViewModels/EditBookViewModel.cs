using BookRegister.Commands;
using BookRegister.Models;
using System;
using System.Windows.Input;

namespace BookRegister.ViewModels
{
    class EditBookViewModel: ViewModelBase
    {
        public EditBookViewModel(string title): this(title, new Book()) {
            
        }

        public EditBookViewModel(string title, Book book)
        {
            Book = book;
            WindowTitle = title;
        }

        #region Properties
        public string WindowTitle { get; set; }
        public Book Book { get; set; }

        public string Authors
        {
            get { return Book.Authors; }
            set
            {
                Book.Authors = value;
                OnPropertyChanged();
            }
        }

        public string Name { 
            get { return Book.Name; }
            set
            {
               Book.Name = value;
                OnPropertyChanged();
            }
        }

        public int PublicationYear
        {
            get { return Book.PublicationYear; }
            set
            {
                Book.PublicationYear = value;
                OnPropertyChanged();
            }
        }

        public DateTime SubmissionDate
        {
            get { return Book.SubmissionDate; }
            set 
            { 
                Book.SubmissionDate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        //private RelayCommand _confirmEditCommand;
        //public ICommand ConfirmEditCommand
        //{
        //    get
        //    {
        //        return _confirmEditCommand ??
        //            (_confirmEditCommand = new RelayCommand(
        //                _ => { },
        //                _ => true)
        //            );
                
        //    }
        //}
        #endregion
    }
}
