using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DAL;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;


namespace LibraryManager.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;

        public SearchController(IBookService bookService, IGenreService genreService)
        {
            _bookService = bookService;
            _genreService = genreService;
        }

        [HttpPost]
        public IActionResult SearchBook(LibraryIndexViewModel model)
        {
            if (model.SearchCategory == "Title")
            {
                var book = _bookService.GetAll().FirstOrDefault(x => x.Title == model.SearchValue);

                if (book == null)
                {
                    return RedirectToAction("Index", "Library");//TODO add error page etc.
                }
                return View("../Library/Open", book);
            }
            else if (model.SearchCategory == "Author")
            {
                var books = _bookService.GetAll().Where(x => model.SearchValue.Contains(x.Author.LastName));

                if (!books.Any())
                {
                    return RedirectToAction("Index", "Library");//TODO add error page etc.
                }
                return View(books);
            }
            else
            {
                var genre = _genreService.GetAll().FirstOrDefault(x => x.GenreName == model.SearchValue);
                if (genre == null)
                {
                    return RedirectToAction("Index", "Library");//TODO add error page etc.
                }
                var books = _bookService.GetAll().Where(x => x.Genres.Contains(genre));
                
                return View(books);
            }
        }

        public IActionResult SortByCategory()
        {
            throw new NotImplementedException();
        }
    }
}