using BooksAPI.Models;
using BooksAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetOneBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult<Book>> SaveBook([FromBody] Book book)
        {
            await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest("ID mismatch.");

            var updatedBook = await _bookService.UpdateBook(book);
            if (updatedBook == null)
                return NotFound();

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteBook(id);
            return success ? NoContent() : NotFound();
        }
    }
}
