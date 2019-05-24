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

namespace LibraryManager.Tests.Controllers
{
    public class LibraryControllerTests
    {
        private readonly LibraryController libraryController;
        private readonly Mock<IUserService> mockUserService;
        private readonly Mock<IBookService> mockBookService;
        private readonly Mock<IGenreService> mockGenreService;
        private readonly Mock<IAdminService> mockAdminService;
        private readonly MockRoleManager mockRoleManager;
        private readonly MockSignInManager mockSignInManager;
        private readonly MockUserManager mockUserManager;

        public LibraryControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            mockBookService = new Mock<IBookService>();
            mockGenreService = new Mock<IGenreService>();
            mockAdminService = new Mock<IAdminService>();
            mockRoleManager = new MockRoleManager();
            mockSignInManager = new MockSignInManager();
            mock
        }

        [Fact]

    }
}
