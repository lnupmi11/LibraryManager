using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class LibraryOpenViewModel
    {
        public BookDTO BookDTO { get; set; }
        public bool IsBookInWishList { get; set; }
        public bool DoesUserReadsBook { get; set; }
    }

}
