namespace ASP.NET_WebAPI6.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        // Navigation property for Books
        public ICollection<Book> Books { get; set; }

    }
}
