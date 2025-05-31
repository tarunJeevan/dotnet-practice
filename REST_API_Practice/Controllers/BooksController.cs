using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_Practice.Data;
using REST_API_Practice.Models;

namespace REST_API_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly REST_API_Practice_Context _context;

        public BooksController(REST_API_Practice_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            // Return all books in database
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            // Retrieve book with matching Id from database
            var book = await _context.Books.FindAsync(id);

            // Check if the retrieved book is valid before returning to user
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            // Check if book is valid
            if (newBook == null)
                return BadRequest();

            // Get all books from database
            var books = await _context.Books.ToListAsync();
            // Check if book already exists in database
            if (books.Contains(newBook))
                return BadRequest("Book already exists");

            // Check if submitted Id is already taken
            var match = books.Where(book => book.Id == newBook.Id);
            if (match.Count() > 0)
                return BadRequest("Invalid ID");

            // Add book to database if all checks pass and sync
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

            // Send 201 status code
            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book updatedBook)
        {
            // Check if book to be updated exists in database
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            // Update book data
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;
            book.ISBN = updatedBook.ISBN;

            // Save data to database
            await _context.SaveChangesAsync();

            // Returns 200 status code and returns updated booklist
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            // Retrieve book with matching Id from booklist
            var book = await _context.Books.FindAsync(id);

            // Check if the retrieved book is valid before returning to user
            if (book == null)
                return NotFound();

            // Delete book from database and save
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            // Return updated list
            return Ok(await _context.Books.ToListAsync());
        }
    }
}
