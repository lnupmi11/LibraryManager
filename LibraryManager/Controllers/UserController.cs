using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void BanUser(int userId)
        {
            throw new NotImplementedException();
        }

        //must return userStatisticDTO
        public void SeeUserStatistic(int userId)
        {
            throw new NotImplementedException();
        }

        //must return ienumerable<userDTO>
        public void SeeUsersList()
        {
            throw new NotImplementedException();
        }
    }
}