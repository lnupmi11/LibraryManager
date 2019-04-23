using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.DAL;
using LibraryManager.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LibraryManager.BLL.Interfaces;

namespace LibraryManager.Controllers
{
    [AllowAnonymous]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public BooksController(IBookService bookService,IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Open(int id)
        {
            var book = _bookService.Find(id);
            if (book == null)
            {
                Response.StatusCode = 404;
            }

            return View(book);
        }

        [AllowAnonymous]
        public IActionResult OpenRandom()
        {
            var numberOfBooks = _bookService.GetAll().Count();
            var random = new Random();
            var randomBook = _bookService.Find(random.Next(0, numberOfBooks));

            if (randomBook == null)
            {
                Response.StatusCode = 404;
            }

            return View("Open", randomBook);
        }


        #region Actions

        public async void AddToWishlist(string userId, int bookId)
        {
            var currentUser =  _userService.GetUser(userId);
            var currentBook = _bookService.Find(bookId);

            //if (currentUser.WishList.Contains(currentBook))
            //{
            //    currentUser.WishList.ToList().Remove(currentBook);
            //}
            //else
            //{
            //    currentUser.WishList.Append(currentBook);
            //}
        }

        public void RateBook(int bookId, int rating)
        {
            var book = _bookService.Find(bookId);

            if (book == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                book.Rating += rating;
                _bookService.Update(book);
            }
        }

        #endregion
    }
}