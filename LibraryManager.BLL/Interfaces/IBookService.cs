using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;

namespace LibraryManager.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        void Create(BookDTO bookDTO);
        BookDTO Find(int id);
        void Delete(int id);
        void Update(BookDTO bookDTO);

        bool isBookAlreadyInUserWishList(string userId, int bookId);
        void AddBookToWishList(string userId, int bookId);
        void DeleteBookFromWishList(string userId, int bookId);
    }
}
