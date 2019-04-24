using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class BookLanguage
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
