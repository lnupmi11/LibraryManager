using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models.Manage;
using LibraryManager.DTO.Models;


namespace LibraryManagerControllers
{
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;

        public LibraryController(IBookService bookService, IUserService userService, IGenreService genreService)
        {
            _bookService = bookService;
            _userService = userService;
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();
            var genres = _genreService.GetAll();

            InitializeTempData();

            var libraryIndexViewModel = new LibraryIndexViewModel
            {
                BookDTOs = books,
                GenreDTOs = genres,
            };

            return View(libraryIndexViewModel);
        }

        public IActionResult IncreaseValue()
        {
            TempData["genreIndex"] = new int? (((int?)TempData["genreIndex"]).Value + 1);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseValue()
        {
            var value = ((int?)TempData["genreIndex"]).Value - 1;
            TempData["genreIndex"] = new int? (value);
            return RedirectToAction("Index");
        }

        public IActionResult Open(int id)
        {
            var book = _bookService.Find(id);
            if (book == null)
            {
                Response.StatusCode = 404;
            }

            return View(book);
        }

        public IActionResult OpenRandom()
        {
            var numberOfBooks = _bookService.GetAll().Count();
            var random = new Random();
            var randomBookId = random.Next(1, numberOfBooks + 1);
            var randomBook = _bookService.Find(randomBookId);

            if (randomBook == null)
            {
                Response.StatusCode = 404;
            }

            return View("Open", randomBook);
        }


        #region Actions

        public void AddToWishlist(string userId, int bookId)
        {
            var currentUser = _userService.GetUser(userId);
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

        private void InitializeTempData()
        {
            if (TempData["wasInitialized"] == null || ((bool?)TempData["wasInitialized"]).Value != true)
            {
                TempData["genreIndex"] = new int?(0);
                TempData["displayedGenres"] = new int?(2);
                TempData["wasInitialized"] = new bool?(true);
            }
        }
        #endregion
    }
}