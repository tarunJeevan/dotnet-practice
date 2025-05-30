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
    }
}
