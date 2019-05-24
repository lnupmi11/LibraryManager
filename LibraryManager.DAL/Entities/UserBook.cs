using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class UserBook
    {
        [Key, Column(Order = 0),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        
        public User User { get; set; }
        [Key, Column(Order = 1)]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public bool IsReading { get; set; }

        public bool IsInWishList { get; set; }

        public bool IsAlreadyFinished { get; set; }

        public bool IsRated { get; set; }
    }
}
