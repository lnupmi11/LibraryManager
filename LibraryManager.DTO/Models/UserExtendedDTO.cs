using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class UserExtendedDTO
    {
       public UserDTO UserDTO { get; set; }
       public int BooksInWishList { get; set; }
       public List<BookDTO> WishList;
    }
}
