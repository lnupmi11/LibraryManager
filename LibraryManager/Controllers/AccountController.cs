using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models.Manage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibraryManager.BLL.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;

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
                var doesEmailExists = await _accountService.DoesEmailExists(model.Email);
                var doesUsernameExists = await _accountService.DoesUsernameExsists(model.UserName);
                if (!doesEmailExists && !doesUsernameExists)
                {
                    var result = await _accountService.RegisterNewUser(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if(doesEmailExists)
                {
                    ModelState.AddModelError("", "This email already exists");
                }
                else if(doesUsernameExists)
                {
                    ModelState.AddModelError("", "This username already exists");
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
                var result = await _accountService.Login(model);
                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or(and) password");
                }                
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