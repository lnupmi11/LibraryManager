using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    public class CustomList
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<ListBook> Books { get; set; }
    }
}
