using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models.Manage;
using LibraryManager.DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManager.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAdminService _adminService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILanguageService _languageService;
        private readonly IAuthorService _authorService;

        public AdminController(IBookService bookService, IGenreService genreService, IAdminService adminService, IHostingEnvironment host,ILanguageService languageService,IAuthorService authorService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _genreService = genreService;
            _adminService = adminService;
            _hostingEnvironment = host;
            _languageService = languageService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            AddNewBookModel addNewBookModel = new AddNewBookModel()
            {
                Genres = new SelectList(_genreService.GetAll(), "Id", "GenreName"),
                Languages =new SelectList(_languageService.GetAll(),"Id", "LanguageName")
            };
            //var genres = _genreService.GetAll().ToList();
            //ViewBag.Genres = new MultiSelectList(genres, "Id", "GenreName");
            return View(addNewBookModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Index(AddNewBookModel book)
        {
            if (ModelState.IsValid)
            {
                AddImage(book);
                AddPdf(book);
                _bookService.Create(book);
            }

            return RedirectToAction("Index", "Library");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAuthor(AuthorDTO author)
        {
            if (ModelState.IsValid)
            {
                _authorService.Create(author);
            }
            return RedirectToAction("Index", "Library");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateGenre()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateGenre(GenreDTO genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Create(genre);
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateLanguage()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateLanguage(LanguageDTO language)
        {
            if (ModelState.IsValid)
            {
                _languageService.Create(language);
            }
            return RedirectToAction("Index", "Admin");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {

            BookDTO book = _bookService.Find(id);
            EditBookViewModel BookModel = _bookService.EditBookDTOToModel(book);
            //ViewData["BookGenre"] = new SelectList(_genreService.GetAll(), "Id", "GenreName");
            return View(BookModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EditBookViewModel bookModel)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(bookModel);
            }
            return RedirectToAction("Open", "Library", new { id = bookModel.Id });
        }

        
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index", "Library");
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

            
            return View(extendedUserDTO);

        }
        private void AddImage(AddNewBookModel model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 1)
            {
                var file = files.ElementAt(1);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var physicalWebRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = "wwwroot\\images" + $@"\{model.Title}" + ".png";

                    using (FileStream fs = System.IO.File.Create($"{physicalWebRootPath}\\{fileName}"))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
        }
        private void AddPdf(AddNewBookModel model)
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Count > 0)
            {
                var file = files.ElementAt(0);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var physicalWebRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = "wwwroot\\images" + $@"\{model.Title}" + ".pdf";

                    using (FileStream fs = System.IO.File.Create($"{physicalWebRootPath}\\{fileName}"))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
        }
    }
    
}