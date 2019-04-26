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
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
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
             
                var result = _accountService.RegisterNewUser(user, model.Password);
                if (result.Result)
                {
                    //Consider about redirecting page
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            return View();
        }
    }
}