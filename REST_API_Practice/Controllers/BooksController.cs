using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using REST_API_Practice.Models;

namespace REST_API_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Create static list in place of database
        static private List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Collapse: How Societies Choose to Fail or Succeed",
                Author = "Jared Diamond",
                YearPublished = 2011,
                ISBN = "9780143117001"
            },
            new Book
            {
                Id = 2,
                Title = "Free to Fall",
                Author = "Lauren Miller",
                YearPublished = 2014,
                ISBN = "9780062199805"
            },
            new Book
            {
                Id = 3,
                Title = "Guns, Germs, and Steel: A short history of everybody for the last 13,000 years",
                Author = "Jared Diamond",
                YearPublished = 1998,
                ISBN = "9780099302780"
            },
            new Book
            {
                Id = 4,
                Title = "Philosophical Phridays: Volume 1",
                Author = "Gregory Kerr",
                YearPublished = 2019,
                ISBN = "9780359434121"
            },
            new Book
            {
                Id = 5,
                Title = "The Arthashastra",
                Author = "Kautilya",
                YearPublished = 2000,
                ISBN = "9788184750119"
            },
            new Book
            {
                Id = 6,
                Title = "Nyxia",
                Author = "Scott Reintgen",
                YearPublished = 2017,
                ISBN = "9780399556821"
            },
            new Book
            {
                Id = 7,
                Title = "Defy the Stars",
                Author = "Claudia Gray",
                YearPublished = 2017,
                ISBN = "9780316394031"
            },
            new Book
            {
                Id = 8,
                Title = "Croak",
                Author = "Gina Damico",
                YearPublished = 2012,
                ISBN = "9780547822563"
            }
        };

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            // Return all books in static list
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            // Retrieve book with matching Id from booklist
            var book = books.FirstOrDefault(temp => temp.Id == id);

            // Check if the retrieved book is valid before returning to user
            if (book == null)
                return NotFound();
                
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book newBook)
        {
            // Check if book is valid
            if (newBook == null)
                return BadRequest();

            if (books.Contains(newBook))
                return BadRequest("Book already exists");

            // Check if submitted Id is already taken
            var match = books.Where(book => book.Id == newBook.Id);
            if (match.Count() > 0)
                return BadRequest("Invalid ID");

            // Add to booklist if all checks pass
            books.Add(newBook);
            // Send 201 status code
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Book>> UpdateBook(int id, Book updatedBook)
        {
            // Check if book to be updated exists in booklist
            var book = books.FirstOrDefault(book => book.Id == id);
            if (book == null)
                return NotFound();

            // Update book
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;
            book.ISBN = updatedBook.ISBN;

            // Returns 200 status code and returns updated booklist
            return Ok(books);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Book>> DeleteBook(int id)
        {
            // Retrieve book with matching Id from booklist
            var book = books.FirstOrDefault(temp => temp.Id == id);

            // Check if the retrieved book is valid before returning to user
            if (book == null)
                return NotFound();

            // Delete book and return updated booklist
            books.Remove(book);
            return Ok(books);
        }
    }
}
