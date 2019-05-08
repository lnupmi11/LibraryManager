using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;

namespace LibraryManager.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        void Create(BookDTO bookDTO);
        BookDTO Find(int id);
        void Delete(int id);
<<<<<<< HEAD
        void Update(EditBookViewModel bookDTO);
=======
        void Update(BookDTO bookDTO);

        bool isBookAlreadyInUserWishList(string userId, int bookId);
        void AddBookToWishList(string userId, int bookId);
        void DeleteBookFromWishList(string userId, int bookId);
>>>>>>> 1d354a83516f154958ef1fa411d98174ce80764b
    }
}
