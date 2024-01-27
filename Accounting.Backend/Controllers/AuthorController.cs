using BookApp.Backend.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Backend.Controllers
{
    [ApiController]
    [Route("Author")]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorContext _context;

        public AuthorController(AuthorContext context)
        {
            _context = context;
        }

        // Liste von allen Authoren anzeigen
        [HttpGet("author")]
        public ActionResult<List<Author>> GetAuthors()
        {
            var authors = _context.Authors.ToList();
            _context.authors.Load();
            return Ok(authors);
        }

        // Abrufen eines bestimmten Autors
        [HttpGet("author/{authorId}")]
        public ActionResult<AuthorController> GetAuthorById(int authorId)
        {
            var author = _context.Book.FirstOrDefault(b => b.AuthorId == authorId);

            if (author == null)
            {
                return NotFound();
            }

            _context.AddAuthors.Load();
            return Ok(author);
        }

        // Author hinzufügen
        [HttpPost("author")]
        public ActionResult<int> CreateAuthor([FromQuery] string authorName)
        {
            var x = new Author();
            x.AuthorName = authorName;
            _context.Authors.Add(x);
            _context.SaveChanges();

            return Ok(10);
        }

        [HttpPut("author/{authorId}")]
        public ActionResult UpdateAuthor(int authorId, [FromBody] Author authorUpdate)
        {
            var existingAuthor = _context.Authors.FirstOrDefault(b => b.AuthorId == authorId);

            if (existingAuthor == null)
            {
                return NotFound();
            }

            existingAuthor.Author = authorUpdate.Id;
            existingAuthor.Author = authorUpdate.AuthorId;
            existingAuthor.Author = authorUpdate.AuthorName;
            existingAuthor.Author = authorUpdate.AuthorDate;

            _context.SaveChanges();

            return Ok(existingAuthor);
        }

        // Buch löschen
        [HttpDelete("author/{authorId}/author")]
        public ActionResult<int> DeleteAuthor([FromRoute] int authorId)
        {

            var author = _context.Authors.First(e => e.Id == authorId);

            _context.Authors.Remove(authorId);
            return Ok();
        }
    }
}
