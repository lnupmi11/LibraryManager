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
using System.Security.Claims;

namespace LibraryManagerControllers
{
    [AllowAnonymous]
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IGenreService _genreService;


        //Temporary
        private readonly IAdminService _adminService;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;

        public LibraryController(IBookService bookService, IUserService userService, IGenreService genreService, RoleManager<IdentityRole> roleManager,UserManager<User> userManager,
            SignInManager<User>signInManager, IAdminService adminService)
        {
            _bookService = bookService;
            _userService = userService;
            _genreService = genreService;

            //Temporary
            _adminService = adminService;

            _roleManager = roleManager;
            _signinManager = signInManager;
            _userManager = userManager;

        }

        public async Task<ActionResult> Index()
        {
            _adminService.GetUsersList();
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
                IsBanned = true
            };
            var Password = "1";//"MyNameIsJohnDoe1_%";
            var tempUser1 = new User
            {
                FirstName = "John2",
                LastName = "Doe2",
                Email = "joh2n@gmail.com",
                UserName = "johnq2",
                IsBanned = false
            };

            var tempUser2 = new User
            {
                FirstName = "John4",
                LastName = "Doe4",
                Email = "john14@gmaiwl.com",
                UserName = "johw124n",
                IsBanned = true
            };

            var admin = new User
            {
                FirstName = "El",
                LastName = "Admino",
                Email = "eladmino@gmail.com",
                UserName = "eladmino",
                IsBanned = false
            };
            var adminPassword = "1"; //"MyNameIsElAdmino1_%";

            var res =  await _userManager.CreateAsync(tempUser, Password);
            var res1 = await _userManager.AddToRoleAsync(tempUser, "User");
            var res5 = await _userManager.CreateAsync(tempUser1, Password);
            var res6 = await _userManager.AddToRoleAsync(tempUser1, "User");
            var res7 = await _userManager.CreateAsync(tempUser2, Password);
            var res8 = await _userManager.AddToRoleAsync(tempUser2, "User");

            var res2 = await _userManager.CreateAsync(admin, adminPassword);
            var res3 = await _userManager.AddToRoleAsync(admin, "Admin");
            var res4 = await _userManager.AddToRoleAsync(admin, "User");

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

            var isBookInWishList = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                isBookInWishList = _bookService.isBookAlreadyInUserWishList(userId, id);
            }

            var libraryOpenViewModel = new LibraryOpenViewModel
            {
                BookDTO = book,
                IsBookInWishList = isBookInWishList
            };
            return View(libraryOpenViewModel);
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
            var book = _bookService.GetRandom();
            var isBookAlreadyInWishList = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                isBookAlreadyInWishList = _bookService.isBookAlreadyInUserWishList(userId, book.Id);
            }

            if (book == null)
            {
                Response.StatusCode = 404;
            }

            var LibraryOpenViewModel = new LibraryOpenViewModel
            {
                BookDTO = book,
                IsBookInWishList = isBookAlreadyInWishList
            };

            return View("Open", LibraryOpenViewModel);
        }
        public FileResult GetReport(string title)
        {
            string ReportURL = "wwwroot\\images\\" + title + ".pdf";
            if (!System.IO.File.Exists(ReportURL))
            {
                byte[] FileBytesDefault = System.IO.File.ReadAllBytes("wwwroot\\images\\ROZKLAD.pdf");
                return File(FileBytesDefault, "application/pdf");
            }
            byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);
            return File(FileBytes, "application/pdf");
        }

        #region Actions

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
                //_bookService.Update(book);
            }
        }
        [Authorize(Roles = "User")]
        public IActionResult AddBookToWishList(int bookId)
        {
            //TODO:create pop up notifying whether book was added or not.
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _bookService.AddBookToWishList(userId,bookId);
            return RedirectToAction("Open", "Library", new { id = bookId });
        }
        [Authorize(Roles = "User")]
        public IActionResult DeleteBookFromWishList(int bookId)
        {
            //TODO:create pop up notifying whether book was added or not.
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _bookService.DeleteBookFromWishList(userId, bookId);
            return RedirectToAction("Open", "Library", new { id = bookId });
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