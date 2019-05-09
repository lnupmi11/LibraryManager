using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        [NotMapped]
        public int NumberOfBooks {
            get => Books?.Count ?? 0;
            set => this.NumberOfBooks = value;
        }

        public ICollection<BookGenre> Books { get; set; }
    }
}
