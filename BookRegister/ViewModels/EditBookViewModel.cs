using BookRegister.Models;
using System;

namespace BookRegister.ViewModels
{
    class EditBookViewModel: ViewModelBase
    {
        private Book _book;

        public EditBookViewModel(string title, Book book)
        {
            _book = book;
            WindowTitle = title;
        }

        #region Properties
        public string WindowTitle { get; set; }

        public string Authors
        {
            get { return _book.Authors; }
            set
            {
                _book.Authors = value;
                OnPropertyChanged();
            }
        }

        public string Name { 
            get { return _book.Name; }
            set
            {
               _book.Name = value;
                OnPropertyChanged();
            }
        }

        public int PublicationYear
        {
            get { return _book.PublicationYear; }
            set
            {
                _book.PublicationYear = value;
                OnPropertyChanged();
            }
        }

        public DateTime SubmissionDate
        {
            get { return _book.SubmissionDate; }
            set 
            { 
                _book.SubmissionDate = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
