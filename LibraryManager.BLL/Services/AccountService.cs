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

        public async Task<bool> RegisterNewUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return true;
            }
            return false;
        }

        public async Task<bool> Login(Tuple<string, string> loginUserData)
        {
            var user = await _userManager.FindByEmailAsync(loginUserData.Item1);

            

            //var result =
            //  _signInManager.PasswordSignInAsync(loginUserData.Item1, loginUserData.Item2, false, false).Result;

            //var result =
            //        _signInManager.SignInAsync(user, false);
            //if (result)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        
    
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}