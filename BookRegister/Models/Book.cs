using BookRegister.ViewModels;
using System;

namespace BookRegister.Models
{
    class Book: ViewModelBase
    {
        public int Id { get; set; }

        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        public Book DeepCopy()
        {
            Book bookCopy = new Book() {
                Id = Id,
                Name = Name,
                Authors = Authors,
                PublicationYear = PublicationYear,
                SubmissionDate = SubmissionDate
            };
            return bookCopy;
        }
    }
}
