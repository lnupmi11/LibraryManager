using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Interfaces;

namespace LibraryManager.DAL.Entities
{
    public class User: IUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public IEnumerable<Book> WishList { get; set; }
        
        public IEnumerable<Book> ReadedBooksCollection { get; set; }
        private User() { }
    }
}
