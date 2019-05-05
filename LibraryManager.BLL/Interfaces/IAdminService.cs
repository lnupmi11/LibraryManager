using LibraryManager.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAdminService
    {
        #region userManaging
        //Ask mentor and consider whether we need to hold all this here or move to userService
        bool BanUser(string email);
        bool UnbanUser(string email);
        Task<UserExtendedDTO> GetDetailedUserInfoAsync(string userName);
        IEnumerable<UserDTO> GetUsersList();
        #endregion
    }
}
