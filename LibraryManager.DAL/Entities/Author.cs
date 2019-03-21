
namespace LibraryManager.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public int NumberOfWrittenBooks { get; set; }

        private Author() { }
    }
}