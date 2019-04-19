using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class UserDTO
    {
        public int Id;

        public string FirstName;

        public IEnumerable<BookDTO> WishList;
    }
}
