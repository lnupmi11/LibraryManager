﻿using System.Collections.Generic;

namespace LibraryManager.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int NumberOfWrittenBooks { get; set; }
    
        public ICollection<Book> Books { get; set; }
    }
}