using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class AuthorDTO
    {
        public string FullName { get; set; }
        public int NumberOfWrittenBooks { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
