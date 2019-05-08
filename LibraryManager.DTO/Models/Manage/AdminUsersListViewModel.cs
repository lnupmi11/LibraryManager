using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class AdminUsersListViewModel
    {
        public IEnumerable<UserDTO> UserDTOs { get; set; }
    }
}
