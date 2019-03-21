using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        string Login { get; set; }

        string Password { get; set; }
    }
}
