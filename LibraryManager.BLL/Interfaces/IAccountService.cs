using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAccountService
    {
       Task<bool> RegisterNewUser(User model, string password);
    }
}
