using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class BookDTO
    {
        public int Id;

        public string Title;

        public AuthorDTO Author;
        

        public double Rating;

        public int NumberOfPages;
    }
}
