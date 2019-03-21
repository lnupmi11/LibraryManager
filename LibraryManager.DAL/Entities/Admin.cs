using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Interfaces;

namespace LibraryManager.DAL.Entities
{
    public class Admin: IUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public IEnumerable<string> ChangesHistoryCollection { get; set; }

        private Admin() { }
    }
}
