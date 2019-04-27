using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class LibraryIndexViewModel
    {
        public IEnumerable<GenreDTO> GenreDTOs { get; set; }

        public IEnumerable<BookDTO> BookDTOs { get; set; }
    }
}
