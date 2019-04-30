using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models.Manage;
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

<<<<<<< HEAD
        public async Task<bool> RegisterNewUser(RegisterViewModel model)
=======
        public async Task<IdentityResult> RegisterNewUser(User user, string password)
>>>>>>> 538ce6e374abd562b5840320b4b47116e99da593
        {
            User user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return result;
        }

<<<<<<< HEAD
        public async Task<bool> Login(LoginViewModel model)
        {
            var result =  await
              _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
=======
        public async Task<SignInResult> Login(Tuple<string, string> loginUserData)
        {
            var result = await
              _signInManager.PasswordSignInAsync(loginUserData.Item1, loginUserData.Item2, false, false);

            //var result =
            //_signInManager.SignInAsync(user, false);
            return result;
>>>>>>> 538ce6e374abd562b5840320b4b47116e99da593
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}