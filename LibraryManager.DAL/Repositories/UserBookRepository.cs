using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Repositories
{
    public class UserBookRepository:IManyToManyRepository<UserBook,string,int>
    {
        private readonly LibraryManagerContext _dbContext;
        private readonly BookRepository _bookRepository;
        private readonly UserRepository _userRepository;

        public UserBookRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
            _bookRepository = new BookRepository(dbContext);
            _userRepository = new UserRepository(dbContext);
        }

        public IQueryable<UserBook> GetAll()
        {
            return _dbContext.UserBooks;
        }
        //REMAKE TO LINQ!
        public IEnumerable<UserBook> GetAllAppropriate(string userId,int bookId)
        {
            var userbooks = _dbContext.UserBooks.ToList();
            var result = new List<UserBook>();
            foreach(var userbook in userbooks)
            {
                if(userbook.UserId==userId && userbook.BookId == bookId)
                {
                    result.Add(userbook);
                }
            }
            return result;
        }
         public UserBook Get(string userId, int bookId)
        {
            var userbook = _dbContext.UserBooks.FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);
            return userbook;
        }
         
        public void Create(UserBook item)
        {
            _dbContext.Add(item);
        }

        public void Update(UserBook item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(string userId, int bookId)
        {
            var userBook = Get(userId,bookId);
            if (userBook != null)
                _dbContext.UserBooks.Remove(userBook);
        }   
    }
}
