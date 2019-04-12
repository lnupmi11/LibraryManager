using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.DAL;
using LibraryManager.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LibraryManager.Controllers
{
    [AllowAnonymous]
    public class BooksController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public BooksController(UserManager<User> manager)
        {
            _unitOfWork = new UnitOfWork();
            _userManager = manager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Open(int id)
        {
            var book = _unitOfWork.Books.Get(id);
            if (book == null)
            {
                Response.StatusCode = 404;
            }

            return View(book);
        }

        [AllowAnonymous]
        public IActionResult OpenRandom()
        {
            var numberOfBooks = _unitOfWork.Books.GetAll().Count();
            var random = new Random();
            var randomBook = _unitOfWork.Books.Get(random.Next(0, numberOfBooks));

            if (randomBook == null)
            {
                Response.StatusCode = 404;
            }

            return View("Open", randomBook);
        }


        #region Actions

        public async void AddToWishlist(string userId, int bookId)
        {
            var currentUser = await _userManager.FindByIdAsync(userId);
            var currentBook = _unitOfWork.Books.Get(bookId);

            if (currentUser.WishList.Contains(currentBook))
            {
                currentUser.WishList.ToList().Remove(currentBook);
            }
            else
            {
                currentUser.WishList.Append(currentBook);
            }
        }

        public void RateBook(int bookId, int rating)
        {
            var book = _unitOfWork.Books.Get(bookId);

            if (book == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                book.Rating += rating;
                _unitOfWork.Books.Update(book);
                _unitOfWork.Save();
            }
        }

        #endregion
    }
}