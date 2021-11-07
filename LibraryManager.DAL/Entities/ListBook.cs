using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class ListBook
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Key, Column(Order = 1)]
        public int CustomListId { get; set; }
        public CustomList CustomList { get; set; }
    }
}

 