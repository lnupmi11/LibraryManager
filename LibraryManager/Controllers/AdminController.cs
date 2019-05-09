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
            BookDTO bookDTO = CreateBookModelToDTO(book);
            if (ModelState.IsValid)
            {
                _bookService.Create(bookDTO);
            }
            return RedirectToAction("Index", "Library");
        }
        [HttpPost]
        public IActionResult Edit(EditBookViewModel bookDTO)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(bookDTO);
            }
            return View(bookDTO);
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
        } 

        public BookDTO CreateBookModelToDTO(AddNewBookModel addNewBookModel)
        {
            BookDTO bookDTO = new BookDTO {
                Title = addNewBookModel.Title,
                Author = new AuthorDTO() { FirstName = addNewBookModel.Author },
                Genres = new List<GenreDTO>() { new GenreDTO() {Id=int.Parse((addNewBookModel.SelectedGenre)) } },
                Languages = new List<LanguageDTO>(),
                Description = addNewBookModel.Description,
                Rating = addNewBookModel.Rating,
                NumberOfPages = addNewBookModel.NumberOfPages
            };
            return bookDTO;
        }

    }
}