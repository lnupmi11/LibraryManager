using LibraryManager.DAL.Entities;
using LibraryManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LibraryManager.BLL.Services;
using LibraryManager.BLL.Interfaces;

namespace LibraryManager.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        private readonly IAccountService _authorizationService;

        public AccountController(IAccountService authorizationService)//<User> userManager, SignInManager<User> signInManager)
        {
            //this._userManager = userManager;
            //this._signInManager = signInManager;
            this._authorizationService = authorizationService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };
             
                var result = _authorizationService.RegisterNewUser(user, model.Password);
                if (result.Result)
                {
                    //Consider about redirecting page
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SignIn(string Login, string Password) //another data for signing up 
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            return View();
        }
    }
}