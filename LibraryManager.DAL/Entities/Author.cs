
namespace LibraryManager.DAL.Entities
{
    public class Author
    {
        /// <summary>
        /// Id of the author in database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Authors' firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Authors' lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Counter of books that author have already written
        /// </summary>
        public int NumberOfWrittenBooks { get; set; }
    }
}