using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(LogIn));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authorization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorization/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(LogIn));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authorization/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authorization/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(LogIn));
            }
            catch
            {
                return View();
            }
        }
    }
}