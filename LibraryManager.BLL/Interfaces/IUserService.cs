using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetAllUsers();
        void AddBookToWishList(UserDTO userDTO, BookDTO bookDTO);
        void ChangeUserName(UserDTO userDTO, string name);
        void ChangeUserSurname(UserDTO userDTO, string surname);
        void Update(UserDTO user);
        void Delete(UserDTO user);

    }
}
