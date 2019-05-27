using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        //[HttpPost]
        //public IActionResult Create()
        //{

        //}
    }
}