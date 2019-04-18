using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Reposetories
{
    public class UserRepository : IRepository<User>
    {
        private LibraryManagerContext context;
        public UserRepository(LibraryManagerContext context)
        {
            this.context = context;
        }

        public void Create(User item)
        {
            context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(User item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
