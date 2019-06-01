using LibraryManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class CommentDTO
    {
        public int Id;

        public string Name;

        public DateTime Date;

        public User User;

        public int BookId;
    }
}
