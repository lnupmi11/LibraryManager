using AutoMapper;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DTO.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.BLL.Services
{
    public class AdminService:IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public bool BanUser(int userId)
        {
            //_userManager.   
            return false;          
        }

        public IEnumerable<UserDTO> GetUsersList()
        {
            var allUsers = _userManager.Users;
            var allUsersDTOs = new List<UserDTO>();
            foreach(var user in allUsers)
            {
                allUsersDTOs.Add(_mapper.Map<UserDTO>(user));
            }
            return allUsersDTOs;
        }

        public void GetUserStatistic()
        {
            throw new NotImplementedException();
        }
    }
}
