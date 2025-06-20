using AutoMapper;
using BookReadingManager.API.Controllers.Base;
using BookReadingManager.Application.DTOs;
using BookReadingManager.Application.Interfaces;
using BookReadingManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BooksController : MainController
    {
        private readonly IBookService _bookService; 
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper, INotificador notificador)
            : base(notificador)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetOneBook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var book = _mapper.Map<Book>(dto);
            await _bookService.AddAsync(book);

            var bookDto = _mapper.Map<BookDto>(book);
            return CustomResponse(dto);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            book.Id = id;

            var updated = await _bookService.UpdateAsync(book);
            if (updated == null)
                return NotFound();

            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
