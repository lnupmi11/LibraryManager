using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.BLL.Services;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManager.DTO.Models.Manage;

namespace LibraryManager.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly LibraryManagerContext _context;
        private readonly IBookService _bookService;

        public AdminController(LibraryManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["BookGenre"] = new SelectList(_context.Genres, "Id", "GenreName");
            return View();
        }

        [HttpPost]
        public IActionResult Index(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                _context.SaveChanges();
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
    }
}