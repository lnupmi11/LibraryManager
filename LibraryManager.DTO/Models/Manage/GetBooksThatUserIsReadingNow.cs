using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class GetBooksThatUserIsReadingNow
    {
        public List<BookDTO> CurrentlyReadingBooks { get; set; }
        public int AlreadyReadBooksPercent { get; set; }
    }
}
