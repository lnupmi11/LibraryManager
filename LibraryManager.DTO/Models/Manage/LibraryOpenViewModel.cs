using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class LibraryOpenViewModel
    {
        public int BookId { get; set; }
        public BookDTO BookDTO { get; set; }
        public IEnumerable<CommentDTO> CommentDTO { get; set; }
        [Required]
        public string newComment { get; set; }
        public bool IsBookInWishList { get; set; }
        public bool DoesUserReadsBook { get; set; }
        public bool IsBookRated { get; set; }
    }

}
