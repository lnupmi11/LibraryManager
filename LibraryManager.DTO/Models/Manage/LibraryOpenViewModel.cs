using LibraryManager.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class LibraryOpenViewModel
    {
        public int BookId { get; set; }
        public BookDTO BookDTO { get; set; }
        public bool IsBookInWishList { get; set; }
        public bool DoesUserReadsBook { get; set; }
        public bool IsBookRated { get; set; }

        public string[] SelectedList { get; set; }
        public MultiSelectList Lists { get; set; }
    }

}
