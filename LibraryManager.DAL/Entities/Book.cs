using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace LibraryManager.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        
        public ICollection<BookGenre> Genres { get; set; }
        
        public ICollection<BookLanguage> Languages { get; set; }

        public ICollection<UserBook> Users { get; set; }
        
        public double Rating { get; set; }
        
        public int NumberOfPages { get; set; }

        public string Description { get; set; }

        public Book() { }
    }
}