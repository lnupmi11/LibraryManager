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

        public async Task<bool> DoesUsernameExsists(string username)
        {
            bool DoesUsernameExsists = true;
            var user = await _userManager.FindByNameAsync(username);
            if(user == null)
            {
                DoesUsernameExsists = false;
            }
            return DoesUsernameExsists;
        }

        public async Task<bool> DoesEmailExists(string email)
        {
            bool DoesEmailExsists = true;
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                DoesEmailExsists = false;
            }
            return DoesEmailExsists;
        }
        public async Task<bool> RegisterNewUser(RegisterViewModel model)
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
            return result.Succeeded;
        }

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
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}