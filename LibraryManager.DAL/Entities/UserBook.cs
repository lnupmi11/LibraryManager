﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class UserBook
    {
        public string UserId { get; set; }
        
        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public bool IsRead { get; set; }
    }
}
