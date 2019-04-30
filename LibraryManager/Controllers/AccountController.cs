using LibraryManager.DAL.Entities;
using LibraryManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibraryManager.BLL.Services;
using LibraryManager.BLL.Interfaces;
using System;

namespace LibraryManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<User> _manager;

        public AccountController(IAccountService accountService, SignInManager<User> manager)
        {
            this._accountService = accountService;
            this._manager = manager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                //Consider moving this to BLL as well.
                //It's needed to solve problem that we cannot reach RegisterViewModel
                // On BLL level so that's why we cannt just pass it as parameter to account service
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _accountService.RegisterNewUser(user, model.Password);
                if (result.Succeeded)
                {
                    //Consider about redirecting page
                    return RedirectToAction("Index", "Library");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Tuple<string, string> loginUserData = new Tuple<string, string>(model.Username, model.Password);
                var result = await _accountService.Login(loginUserData);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Library");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or(and) password");
                }
                var a = await _manager.PasswordSignInAsync(model.Username, model.Password, false, false);
            }
            return View(model);
        }
        
        public IActionResult Logout()
        {
            _accountService.Logout();
           return RedirectToAction("Index", "Library");
        }
    }
}