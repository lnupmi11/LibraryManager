using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;

namespace LibraryManager.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void ChangeUserName(User user, string name)
        {
            user.FirstName = name;

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }

        public void ChangeUserSurname(User user, string surname)
        {
            user.LastName = surname;

            _unitOfWork.UserRepository.Update(user);
        }

        public void Delete(User user)
        {

            _unitOfWork.UserRepository.Delete(user.Id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll();

            return users;
        }

        public User GetUser(string id)
        {
           var user = _unitOfWork.UserRepository.Get(id);

            return user;
        }

        public void Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }

    }
}
