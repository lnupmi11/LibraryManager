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
<<<<<<< HEAD
       Task<bool> RegisterNewUser(RegisterViewModel model);
       Task<bool> Login(LoginViewModel model);
=======
       Task<IdentityResult> RegisterNewUser(User model, string password);
       Task<SignInResult> Login(Tuple<string,string> loginUserData);
>>>>>>> 538ce6e374abd562b5840320b4b47116e99da593
       void Logout();
    }
}
