using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public Language() { }
    }
}
