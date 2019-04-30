using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models.Manage;

using Microsoft.AspNetCore.Identity;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAccountService
    {
       Task<bool> DoesEmailExsists(string email);
       Task<bool> RegisterNewUser(RegisterViewModel model);
       Task<bool> Login(LoginViewModel model);
       void Logout();
    }
}
