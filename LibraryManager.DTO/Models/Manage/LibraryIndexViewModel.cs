using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class LibraryIndexViewModel
    {
        public IEnumerable<GenreDTO> GenreDTOs { get; set; }

        public IEnumerable<BookDTO> BookDTOs { get; set; }

        public IEnumerable<LanguageDTO> LanguageDTOs { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }

        public string SearchCategory { get; set; }
        public string SearchValue { get; set; }
    }
}
