using LibraryManager.BLL.Interfaces;
using LibraryManager.Controllers;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LibraryManager.Tests
{
    public class SearchControllerTests
    {

        private readonly SearchController searchController;
        private readonly Mock<IBookService> mockBookService;
        private readonly Mock<IGenreService> mockGenreService;
        private readonly Mock<ILanguageService> mockLanguageService;

        public SearchControllerTests()
        {
            mockBookService = new Mock<IBookService>();
            mockGenreService = new Mock<IGenreService>();
            mockLanguageService = new Mock<ILanguageService>();
            searchController = new SearchController(mockBookService.Object, mockGenreService.Object, mockLanguageService.Object);

        }

        [Fact]
        public void SearchBookByTitleTest()
        {
            mockBookService.Setup(m => m.GetAll()).Returns(new List<BookDTO>());

            var model = new LibraryIndexViewModel { SearchCategory = "Title" };

            var result = searchController.SearchBook(model);

            Assert.NotNull(result);
        }

        [Fact]
        public void SearchBookTest()
        {
            mockBookService.Setup(m => m.GetAll()).Returns(new List<BookDTO>());

            var model = new LibraryIndexViewModel();

            var result = searchController.SearchBook(model);

            Assert.NotNull(result);
        }
    }
}
