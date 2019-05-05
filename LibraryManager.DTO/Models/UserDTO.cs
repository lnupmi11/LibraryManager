using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class UserDTO
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set;}       
        public string Role { get; set; }
    }
}