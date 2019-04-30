using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace LibraryManager.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterNewUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }

        public async Task<SignInResult> Login(Tuple<string, string> loginUserData)
        {
            var result = await
              _signInManager.PasswordSignInAsync(loginUserData.Item1, loginUserData.Item2, false, false);

            //var result =
            //_signInManager.SignInAsync(user, false);
            return result;
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}