using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
