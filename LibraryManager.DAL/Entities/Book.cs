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

        [ForeignKey("Genre")]
        public int GenreId { get; set;}
        public Genre Genre { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        [NotMapped]
        public Language Language { get; set; }

      //  public IEnumerable<Genre> GenresCollection { get; set; }
        
       // public IEnumerable<Language> AvailableLanguagesCollection { get; set; }
        
        public double Rating { get; set; }
        
        public int NumberOfPages { get; set; }

        public Book() { }
    }
}