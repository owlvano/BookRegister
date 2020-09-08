using System;

namespace BookRegister.Models
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
