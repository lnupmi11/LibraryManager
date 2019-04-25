using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class AuthorizationController : Controller
    {
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string Login,string Password)
        {
            return View();
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