using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LibraryManager.BLL.Interfaces;
using LibraryManager.BLL.Services;
using Moq;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;
using AutoMapper;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;
using LibraryManager.DAL;
using System.Linq;
using LibraryManagerControllers;
using Microsoft.AspNetCore.Identity;
using LibraryManager.Tests.CustomMocks;
using Microsoft.Extensions.Logging;

namespace LibraryManager.Tests.Controllers
{
    public class LibraryControllerTests
    {
        private readonly LibraryController libraryController;
        private readonly Mock<IUserService> mockUserService;
        private readonly Mock<IBookService> mockBookService;
        private readonly Mock<IGenreService> mockGenreService;
        private readonly Mock<IAdminService> mockAdminService;
        private readonly Mock<RoleManager<IdentityRole>> mockRoleManager;
        private readonly MockSignInManager mockSignInManager;
        private readonly MockUserManager mockUserManager;

        private const int Id = 1;

        public LibraryControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            mockBookService = new Mock<IBookService>();
            mockGenreService = new Mock<IGenreService>();
            mockAdminService = new Mock<IAdminService>();
            mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                    new Mock<IRoleStore<IdentityRole>>().Object,
                    new IRoleValidator<IdentityRole>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<ILogger<RoleManager<IdentityRole>>>().Object);
            mockSignInManager = new MockSignInManager();
            mockUserManager = new MockUserManager();

            libraryController = new LibraryController(
                mockBookService.Object, mockUserService.Object, mockGenreService.Object,
                mockRoleManager.Object, mockUserManager, mockSignInManager, mockAdminService.Object);
        }

        [Fact]
        public async void IndexTest()
        {
            mockBookService.Setup(m => m.GetAll()).Returns(new List<BookDTO>());
            mockGenreService.Setup(m => m.GetAll()).Returns(new List<GenreDTO>());

            var result = await libraryController.Index();

            Assert.NotNull(result);
        }

        [Fact]
        public void OpenTest()
        {
            mockBookService.Setup(m => m.Find(Id)).Returns(new BookDTO() { Id = Id });

            var result = libraryController.Open(Id);

            Assert.NotNull(result);
        }

        [Fact]
        public void OpenByGenreTest()
        {
            mockBookService.Setup(m => m.GetAll()).Returns(new List<BookDTO>());
            mockGenreService.Setup(m => m.Find(Id)).Returns(new GenreDTO());

            var result = libraryController.OpenByGenre(Id);

            Assert.NotNull(result);
        }
         
        [Fact]
        public void OpenRandomTest()
        {
            mockBookService.Setup(m => m.GetRandom()).Returns(new BookDTO());

            var result = libraryController.OpenRandom();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetReportTest()
        {
            var title = "Freeman";
            var result = libraryController.GetReport(title);

            Assert.NotNull(result);
        }
    }
}
