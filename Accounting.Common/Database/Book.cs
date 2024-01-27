namespace BookApp.Backend.Database
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

    public class BookUpdate
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }

}
