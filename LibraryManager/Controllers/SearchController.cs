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
        private readonly ILanguageService _languageService;

        public SearchController(IBookService bookService, IGenreService genreService,ILanguageService languageService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _languageService= languageService;
        }

        [HttpPost]
        public IActionResult SearchBook(LibraryIndexViewModel model)
        {
            if (model.SearchCategory == "Title")
            {
                var book = _bookService.GetAll().FirstOrDefault(x => x.Title.ToLower().Contains(model.SearchValue.ToLower()));

                if (book == null)
                {
                    return RedirectToAction("Index", "Library");
                }
                return RedirectToAction("Open", "Library", new { id = book.Id });
            }
            else if (model.SearchCategory == "Language")
            {
                var book = _bookService.GetAll().Where(y => y.Languages.Where(z => z.LanguageName.ToLower().Contains(model.SearchValue.ToLower())).Count()>0).ToList();

                if (book == null)
                {
                    return RedirectToAction("Index", "Library");
                }
                return View(book);
            }
            else if (model.SearchCategory == "Year")
            {
                var book = _bookService.GetAll().Where(x => x.Year.ToString()==model.SearchValue).ToList();

                if (book == null)
                {
                    return RedirectToAction("Index", "Library");
                }
                return View(book);
            }
            var books = _bookService.GetAll().Where(x => model.SearchValue.ToLower().Contains(x.Author.LastName.ToLower()));

            if (!books.Any())
            {
                return RedirectToAction("Index", "Library");
            }
            return View(books);
        }

        public IActionResult SortByCategory()
        {
            throw new NotImplementedException();
        }
    }
}