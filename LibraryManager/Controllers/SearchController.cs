using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DAL;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class SearchController : Controller
    {

        private UnitOfWork _unitOfWork;

        public SearchController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
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