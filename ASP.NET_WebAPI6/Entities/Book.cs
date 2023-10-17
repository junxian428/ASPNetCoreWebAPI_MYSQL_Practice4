namespace ASP.NET_WebAPI6.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        // Foreign key property
        public int AuthorId { get; set; }

        // Navigation property for Author
        public Author Author { get; set; }

    }
}
