using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public ICollection<BookGenre> Books { get; set; }
    }
}
