using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models.Manage;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAccountService
    {
       Task<bool> RegisterNewUser(RegisterViewModel model);
       Task<bool> Login(LoginViewModel model);
       void Logout();
    }
}
