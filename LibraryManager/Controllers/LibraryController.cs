using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.BLL.Interfaces;


namespace LibraryManagerControllers
{
    public class LibraryController : Controller
    {
        IBookService _bookService;

        public LibraryController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var books = _bookService.GetAll();

            return View(books);
        }
    }
}
