using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    class User
    {
        /// <summary>
        /// Id of the user in database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Users' firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Users' lasstname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Whishlist of each users
        /// </summary>
        public IEnumerable<Book> Whishlist { get; set; }

        /// <summary>
        /// Collection of readed books
        /// </summary>
        public IEnumerable<Book> ReadedBooksCollection { get; set; }
    }
}
