using System;
using System.Collections.Generic;
using System.Text;


namespace LibraryManager.DTO.Models
{
    public class LanguageDTO
    {
        public int Id;

        public string LanguageName;

        public IEnumerable<BookDTO> Books;
    }
}
