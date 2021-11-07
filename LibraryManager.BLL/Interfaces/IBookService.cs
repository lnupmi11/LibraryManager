using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;

namespace LibraryManager.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        void Create(AddNewBookModel bookModel);
        BookDTO Find(int id);
        void Delete(int id);
        void Update(EditBookViewModel bookDTO);
        bool isBookAlreadyInUserWishList(string userId, int bookId);
        void AddBookToWishList(string userId, int bookId);
        void DeleteBookFromWishList(string userId, int bookId);
        EditBookViewModel EditBookDTOToModel(BookDTO bookDTO);
        BookDTO GetRandom();
        bool DoesUserReadsBook(string userId, int bookId);
        void StopReadingBook(string userId, int bookId);
        void StartReadingBook(string userId, int bookId);
        IEnumerable<BookDTO> BooksFromUserLibrary(string userId);
        void FinishReadingBook(string userId, int bookId);
        float GetAlreadyReadBooksPercentage(string userId);
        IEnumerable<BookDTO> GetBooksFromWishList(string userId);
        bool IsBookFinished(string userId, int bookId);
        Dictionary<string, int> GetUserBooksByGenreStatistics(string userId);
        void RateBook(string userId, int bookId);
        bool IsBookRated(string userId, int bookId);

        void CreateCustomListForUser(string userId,string customListName);
        void DeleteCustomList(int id);

        void AddBookToCustomList(int customListId, int bookId);
        void DeleteBookFromCustomList(int customListId, int bookId);

        IEnumerable<CustomList> GetUserCustomLists(string userId);
        CustomList OpenCustomList(int id);

    }
}
