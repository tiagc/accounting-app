using BookApp.Backend.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Backend.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        // Liste von allen Büchern anzeigen
        [HttpGet("book")]
        public ActionResult<List<Book>> GetBooks()
        {
            var books = _context.Books.ToList();
            _context.Books.Load();
            return Ok(books);
        }

        // Abrufen eines Buches mit BookId
        [HttpGet("book/{bookId}")]
        public ActionResult<BookController> GetBookById(int bookId)
        {
            var book = _context.Book.FirstOrDefault(b => b.BookId == bookId);

            if (book == null)
            {
                return NotFound();
            }

            _context.AddBooks.Load();
            return Ok(book);
        }

        // Buch erstellen
        [HttpPost("book")]
        public ActionResult<int> CreateBook([FromQuery] string bookName)
        {
            var x = new Book();
            x.BookName = bookName;
            _context.Books.Add(x);
            _context.SaveChanges();

            return Ok(10);
        }

        [HttpPut("book/{bookId}")]
        public ActionResult UpdateBook(int bookId, [FromBody] Book bookUpdate)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.BookId == bookId);

            if (existingBook == null)
            {
                return NotFound(); // If the book with the specified ID is not found
            }

            // Update the properties of the existing book based on the data in bookUpdateDto
            existingBook.Title = bookUpdate.Title;
            existingBook.Author = bookUpdate.Author;
            existingBook.PublishDate = bookUpdate.PublishDate;
            // Add more properties as needed

            _context.SaveChanges();

            return Ok(existingBook);
        }

        // Buch löschen
        [HttpDelete("book/{bookId}/book")]
        public ActionResult<int> DeleteBook([FromRoute] int bookId)
        {

            var bill = _context.Books.First(e => e.Id == bookId);

            _context.Books.Remove(bookId);
            return Ok();
        }
    }
}
