using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.BLL.Interfaces;
using LibraryManager.BLL.Services;
using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Repositories;
using LibraryManager.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManager.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;

        public AdminController(IBookService bookService,IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["BookGenre"] = new SelectList(_genreService.GetAll(), "Id", "GenreName");
            return View();
        }

        [HttpPost]
        public IActionResult Index(BookDTO book)
        {

            if (ModelState.IsValid)
            {
                _bookService.Create(book);
            }
            return RedirectToAction("Index", "Library");
        }
    }
}