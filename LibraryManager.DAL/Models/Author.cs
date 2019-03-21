using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int  NumberOfWrittenBooks { get; set; }
    }
}
