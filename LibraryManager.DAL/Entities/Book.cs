
using System.Collections.Generic;

namespace LibraryManager.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public Author Author { get; set; }
        
        public IEnumerable<Genre> GenresCollection { get; set; }
        
        public IEnumerable<Language> AvailableLanguagesCollection { get; set; }
        
        public double Rating { get; set; }
        
        public int NumberOfPages { get; set; }
    }
}