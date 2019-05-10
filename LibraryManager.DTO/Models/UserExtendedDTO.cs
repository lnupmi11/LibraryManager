using LibraryManager.DTO.Checker;
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
        public string ImageName
        {
            get
            {
                if (UserDTO.UserName == null)
                    return "DefaultUser.png";

                var imageName = UserDTO.UserName + ".png";
                return ImageChecker.ImageExists(imageName) ? imageName : "DefaultUser.png";
            }
        }
    }
}
