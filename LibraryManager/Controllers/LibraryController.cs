using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.DAL;

namespace LibraryManager.Controllers
{
    public class LibraryController : Controller
    {
        private UnitOfWork _unitOfWork;

        public LibraryController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IActionResult Index()
        {
            var books = _unitOfWork.Books.GetAll();
            return View();
        }

        public IActionResult Open(int id)
        {
            var book = _unitOfWork.Books.Get(id);
            if (book == null)
            {
                //TODO: Return 404 page.
                return null;
            }

            return View(book);
        }

        public IActionResult OpenRandom()
        {
            var numberOfBooks = _unitOfWork.Books.GetAll().Count();
            var random = new Random();
            var randomBook = _unitOfWork.Books.Get(random.Next(0, numberOfBooks));

            if (randomBook == null)
            {
                //TODO: Return error page.
                return null;
            }

            return View("Open", randomBook);
        }

        public IActionResult RateBook(int id, int rating)
        {
            var book = _unitOfWork.Books.Get(id);
            if (book == null)
            {
                //TODO: Return 404 page.
                return null;
            }

            book.Rating += rating;
            _unitOfWork.Books.Update(book);
            _unitOfWork.Save();

            return View("Index");
        }
    }
}