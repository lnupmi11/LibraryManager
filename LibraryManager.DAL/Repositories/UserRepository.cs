using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Repositories
{
    public class UserRepository : IRepository<User, string>
    {
        private LibraryManagerContext _dbContext;
        public UserRepository(LibraryManagerContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Create(User item)
        {
            _dbContext.Users.Add(item);
        }

        public void Delete(string id)
        {
            var user = Get(id);
            if(user != null)
                _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public User Get(string id)
        {
            var userWishList = _dbContext.UserBooks.Where(ub => ub.UserId == id);
            var user = GetAll().FirstOrDefault(u => u.Id == id);
            user.WishList = userWishList.ToList();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public void Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
