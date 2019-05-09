using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models.Manage;
using Microsoft.AspNetCore.Identity;
using LibraryManager.DAL.Entities;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagerControllers
{
    [AllowAnonymous]
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;


        //Temporary
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;

        public LibraryController(IBookService bookService, IUserService userService, IGenreService genreService, RoleManager<IdentityRole> roleManager,UserManager<User> userManager,
            SignInManager<User>signInManager)
        {
            _bookService = bookService;
            _userService = userService;
            _genreService = genreService;

            //Temporary
            _roleManager = roleManager;
            _signinManager = signInManager;
            _userManager = userManager;

        }

        public async Task<ActionResult> Index()
        {
            var books = _bookService.GetAll();
            var genres = _genreService.GetAll();

            InitializeTempData();

            var libraryIndexViewModel = new LibraryIndexViewModel
            {
                BookDTOs = books,
                GenreDTOs = genres,
            };



            //TEMPORARY CODE. 
             await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await  _roleManager.CreateAsync(new IdentityRole("User"));

            var tempUser = new User {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@gmail.com",
                UserName = "john",               
            };
            var Password = "1";//"MyNameIsJohnDoe1_%";

            var admin = new User
            {
                FirstName = "El",
                LastName = "Admino",
                Email = "eladmino@gmail.com",
                UserName = "eladmino",
            };
            var adminPassword = "1"; //"MyNameIsElAdmino1_%";

            var res =  await _userManager.CreateAsync(tempUser, Password);
            var res1 = await _userManager.AddToRoleAsync(tempUser, "User");

            var res2 = await _userManager.CreateAsync(admin, adminPassword);
            var res3 = await _userManager.AddToRoleAsync(admin, "Admin");

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

        public IActionResult OpenByGenre(int id)
        {
            var genre = _genreService.Find(id);
            if (genre == null)
            {
                Response.StatusCode = 404;
            }

            var books = _bookService.GetAll().Where(x => x.Genres.All(y => y.GenreName == genre.GenreName));

            return View(books);
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
                TempData["displayedGenres"] = new int?(4);
                TempData["wasInitialized"] = new bool?(true);
            }
        }
        #endregion
    }
}