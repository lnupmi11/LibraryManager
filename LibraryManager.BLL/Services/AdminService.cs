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
     

        public AdminService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;  
        }

        public bool BanUser(string email)
        {
            var userToBan = _userManager.FindByEmailAsync(email).Result;
            var isUserToBanAdmin = _userManager.IsInRoleAsync(userToBan, "Admin").Result;
            if(!isUserToBanAdmin)
            {
                userToBan.IsBanned = true;
                _unitOfWork.Save();
                return false;
            }
            return false;
        }

        public bool UnbanUser(string email)
        {
            var userToUnban = _userManager.FindByEmailAsync(email).Result;
            if(userToUnban.IsBanned)
            {
                userToUnban.IsBanned = false;
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public IEnumerable<UserDTO> GetUsersList()
        {
            var allUsers = _userManager.Users;
            var allUsersDTOs = new List<UserDTO>();
            foreach(var user in allUsers)
            {
                allUsersDTOs.Add(customUserDTOmapper(user));
            }
            return allUsersDTOs;
        }

        public void GetUserStatistic()
        {
            throw new NotImplementedException();
        }

        //Use instead of AutoMapper because of problem with mapping Roles(acquiring, setting them etc.)
        private UserDTO customUserDTOmapper(User user)
        {
            var role = _userManager.IsInRoleAsync(user, "Admin").Result ? "Admin" : "User";

            return new UserDTO {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                IsBanned = user.IsBanned,
                Role = role
            };
        }
    }
}
