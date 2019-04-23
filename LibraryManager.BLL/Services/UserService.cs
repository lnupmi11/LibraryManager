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
        private readonly IRepository<User, string> _userRepository;

        private readonly IMapper _mapper;

        public UserService(IRepository<User, string> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void AddBookToWishList(User user, BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            //if (user.WishList.Contains(book))
            //{
            //    user.WishList.Remove(book);
            //}
            //else
            //{
            //    user.WishList.Add(book);
            //}

            _userRepository.Update(user);
        }

        public void ChangeUserName(User user, string name)
        {
            user.FirstName = name;

            _userRepository.Update(user);
        }

        public void ChangeUserSurname(User user, string surname)
        {
            user.LastName = surname;

            _userRepository.Update(user);
        }

        public void Delete(User user)
        {

            //_userRepository.Delete(user.Id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return users;
        }

        public User GetUser(string id)
        {
            var user = _userRepository.Get(id);

            return user;
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
