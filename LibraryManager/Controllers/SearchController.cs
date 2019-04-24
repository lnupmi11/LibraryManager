using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DAL;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models;


namespace LibraryManager.Controllers
{
    public class SearchController : Controller
    {
        ILanguageService _languageService;

        public SearchController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var language = ShowLanguage();
            return View(language);
        }


        public IEnumerable<LanguageDTO> ShowLanguage()
        {
            var allLanguage = _languageService.GetAll();
            return (allLanguage);
        }

        public IActionResult SearchBook(string bookName)
        {
            //var book = _unitOfWork.BookRepository.Get(bookName);
            //if (book == null)
            //{
            //    //TODO: Return 404 page.
            //    return null;
            //}

            return View(/*book*/);
        }

        public IActionResult SortByCategory()
        {
            throw new NotImplementedException();
        }
    }
}