using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;

using Microsoft.AspNetCore.Identity;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAccountService
    {
       Task<IdentityResult> RegisterNewUser(User model, string password);
       Task<SignInResult> Login(Tuple<string,string> loginUserData);
       void Logout();
    }
}
