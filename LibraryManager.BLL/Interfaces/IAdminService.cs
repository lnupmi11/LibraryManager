using LibraryManager.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAdminService
    {
        #region userManaging
        //Ask mentor and consider whether we need to hold all this here or move to userService
        bool BanUser(int userId);
        void GetUserStatistic();
        IEnumerable<UserDTO> GetUsersList();
        #endregion
    }
}
