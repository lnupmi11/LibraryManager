using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;
using LibraryManager.DAL.Entities;

namespace LibraryManager.BLL.Interfaces
{
    public interface IUserService
    {
        User GetUser(string id);
        IEnumerable<User> GetAllUsers();
        void ChangeUserName(User userDTO, string name);
        void ChangeUserSurname(User userDTO, string surname);
        void Update(User user);
        void Delete(User user);

    }
}
