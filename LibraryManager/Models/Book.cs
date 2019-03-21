using System.Collections.Generic;

namespace LibraryManager.Models
{
    public class Book
    {
        /// <summary>
        /// Id of the book in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Collection of genres the book is written in.
        /// </summary>
        public IEnumerable<Genre> GenresCollection { get; set; }

        /// <summary>
        /// Languages the book is translated to.
        /// </summary>
        public IEnumerable<Language> AvailableLanguagesCollection { get; set; }

        /// <summary>
        /// Rating of the book.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Number of the pages.
        /// </summary>
        public int NumberOfPages { get; set; }
    }
}
