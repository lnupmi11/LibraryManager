using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.API.Controllers;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;
using LibraryManager.Tests.CustomMocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LibraryManager.Tests.Controllers
{
    public class AdminControllerTests
    {
        private readonly AdminController adminController;
        private readonly Mock<IUserService> mockUserService;
        private readonly Mock<IBookService> mockBookService;
        private readonly Mock<IGenreService> mockGenreService;
        private readonly Mock<IAdminService> mockAdminService;
        private readonly Mock<ILanguageService> mockLanguageService;
        private readonly Mock<IHostingEnvironment> mockHostingEnv;
        private readonly MockSignInManager mockSignInManager;
        private readonly MockUserManager mockUserManager;

        private const int Id = 1;

        public AdminControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            mockBookService = new Mock<IBookService>();
            mockGenreService = new Mock<IGenreService>();
            mockAdminService = new Mock<IAdminService>();
            mockHostingEnv = new Mock<IHostingEnvironment>();
            mockLanguageService = new Mock<ILanguageService>();
            mockSignInManager = new MockSignInManager();
            mockUserManager = new MockUserManager();

            adminController = new AdminController(
                mockBookService.Object, mockGenreService.Object, mockAdminService.Object, mockHostingEnv.Object, mockLanguageService.Object);
        }
        [Fact]
        public void IndexTest()
        {
            mockLanguageService.Setup(m => m.GetAll()).Returns(new List<LanguageDTO>());
            mockGenreService.Setup(m => m.GetAll()).Returns(new List<GenreDTO>());

            var result =  adminController.Index();

            mockLanguageService.Verify(x => x.GetAll(),Times.Exactly(1));
            mockGenreService.Verify(x => x.GetAll(), Times.Exactly(1));
            Assert.NotNull(result);
        }
        [Fact]
        public void CreateGenreTest()
        {
            var genre = new GenreDTO();

            var result = adminController.CreateGenre(genre);

            mockGenreService.Verify(x => x.Create(genre), Times.Exactly(1));
            Assert.NotNull(result);
        }
        [Fact]
        public void CreateLanguageTest()
        {
            var language = new LanguageDTO();

            var result = adminController.CreateLanguage(language);

            mockLanguageService.Verify(x => x.Create(language), Times.Exactly(1));
            Assert.NotNull(result);
        }
        [Fact]
        public void EditTest()
        {
            var book = new EditBookViewModel();

            var result = adminController.Edit(book);

            mockBookService.Verify(x => x.Update(book), Times.Exactly(1));
            Assert.NotNull(result);
        }
        [Fact]
        public void EditByIdTest()
        {
            int id = 1;

            var result = adminController.Edit(id);

            mockBookService.Verify(x => x.Find(id), Times.Exactly(1));
            mockBookService.Verify(x => x.EditBookDTOToModel(It.IsAny<BookDTO>()), Times.Exactly(1));
            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteTest()
        {
            int id = 1;

            var result = adminController.Delete(id);

            mockBookService.Verify(x => x.Delete(id), Times.Exactly(1));
            Assert.NotNull(result);
        }
        [Fact]
        public void GetUsersListTest()
        {
            var result = adminController.GetUsersList();

            mockAdminService.Verify(x => x.GetUsersList(), Times.Exactly(1));
            Assert.NotNull(result);
        }
    }
}
