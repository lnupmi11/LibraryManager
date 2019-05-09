using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.BLL.Interfaces;
using LibraryManager.BLL.Services;
using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Repositories;
using LibraryManager.DTO.Models.Manage;
using LibraryManager.DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManager.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAdminService _adminService;

        public AdminController(IBookService bookService, IGenreService genreService, IAdminService adminService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _adminService = adminService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            AddNewBookModel addNewBookModel = new AddNewBookModel() { Genres = new SelectList(_genreService.GetAll(), "Id", "GenreName")};
            ViewData["BookGenre"] = new SelectList(_genreService.GetAll(), "Id", "GenreName");
            return View(addNewBookModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Index(AddNewBookModel book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Create(book);
            }
            return RedirectToAction("Index", "Library");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {

            BookDTO book = _bookService.Find(id);
            EditBookViewModel BookModel = _bookService.EditBookDTOToModel(book);
            //ViewData["BookGenre"] = new SelectList(_genreService.GetAll(), "Id", "GenreName");
            return View(BookModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel bookModel)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(bookModel);
            }
            return RedirectToAction("Open", "Library", new { id = bookModel.Id });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsersList()
        {
            var users = _adminService.GetUsersList();
            var UsersListViewModel = new AdminUsersListViewModel {
                UserDTOs = users
            };

            return View(UsersListViewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult BanUser(string email)
        {
            _adminService.BanUser(email);
            return RedirectToAction("GetUsersList", "Admin");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UnbanUser(string email)
        {
            _adminService.UnbanUser(email);
            return RedirectToAction("GetUsersList", "Admin");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetDetailedUserInfo(string userName)
        {
            //Change later
            if (userName == null)
            {
                return RedirectToAction("Index", "Library");
            }
            var extendedUserDTO =  _adminService.GetDetailedUserInfoAsync(userName).Result;

            if(extendedUserDTO.BooksInWishList==0)
            {
                return RedirectToAction("Index", "Library");
            }
            return View(extendedUserDTO);
<<<<<<< HEAD
=======
        } 

        public BookDTO CreateBookModelToDTO(AddNewBookModel addNewBookModel)
        {
            BookDTO bookDTO = new BookDTO {
                Title = addNewBookModel.Title,
                Author = new AuthorDTO() { FirstName = addNewBookModel.AuthorName,LastName=addNewBookModel.AuthorSurname },
                Genres = new List<GenreDTO>() { new GenreDTO() {Id=int.Parse((addNewBookModel.SelectedGenre)) } },
                Languages = new List<LanguageDTO>(),
                Description = addNewBookModel.Description,
                Rating = addNewBookModel.Rating,
                NumberOfPages = addNewBookModel.NumberOfPages
            };
            return bookDTO;
>>>>>>> eb28042c1964f7b1f61c79d92b2a2a3acac9f057
        }

    }
}