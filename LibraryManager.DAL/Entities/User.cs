using Microsoft.AspNetCore.Identity;
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
            
        public bool IsBanned { get; set; }
        //FIXING UserId1 bug 
        // Maybe we should create model of WishList and ReadBookColection separatly and link records
        // there with userId instead of expanding user entity?

        public ICollection<UserBook> WishList { get; set; }

        public User() { }
    }
}
