﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManager.DAL.Entities
{
    public class User: IdentityUser
    {

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public List<Book> WishList { get; set; }
        
        public IEnumerable<Book> ReadedBooksCollection { get; set; }
        private User() { }
    }
}
