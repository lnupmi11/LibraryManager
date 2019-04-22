using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public IEnumerable<Book> Book { get; set; }
    }
}
