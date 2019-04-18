using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;

namespace LibraryManager.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void AddBookToWishList(UserDTO userDTO, BookDTO bookDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var book = _mapper.Map<Book>(bookDTO);

            if (user.WishList.Contains(book))
            {
                user.WishList.Remove(book);
            }
            else
            {
                user.WishList.Add(book);
            }

            _userRepository.Update(user);
        }

        public void ChangeUserName(UserDTO userDTO, string name)
        {
            var user = _mapper.Map<User>(userDTO);
            user.FirstName = name;

            _userRepository.Update(user);
        }

        public void ChangeUserSurname(UserDTO userDTO, string surname)
        {
            var user = _mapper.Map<User>(userDTO);
            user.LastName = surname;

            _userRepository.Update(user);
        }

        public void Delete(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            //_userRepository.Delete(user.Id);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var user in user)
            {
                usersDTO.Add(_mapper.Map<UserDTO>(user));
            }

            return usersDTO;
        }

        public UserDTO GetUser(int id)
        {
            _userRepository.Delete(id);
        }

        public void Update(UserDTO user)
        {
            _userRepository.Update(user);
        }
    }
}
