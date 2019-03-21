namespace LibraryManager.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
        private Category() { }
    }
}
