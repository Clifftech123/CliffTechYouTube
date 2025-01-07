using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.API.Domain.Contracts;
using RepositoryPattern.API.Domain.Entities;
using RepositoryPattern.API.Repositories;

namespace RepositoryPattern.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookController : ControllerBase
    {

        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBaseRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        [HttpGet("books")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookRepository.GetAll(a => a.Author);
            var bookDtos = _mapper.Map<List<GetBookDto>>(books);
            return Ok(bookDtos);
        }


        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            var book = await _bookRepository.Get(id, a => a.Author);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<GetBookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost("books")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBook createBook)
        {
            var book = _mapper.Map<Book>(createBook);
            var createdBook = await _bookRepository.Add(book);
            var bookDto = _mapper.Map<GetBookDto>(createdBook);
            return CreatedAtAction(nameof(GetBook), new { id = bookDto.Id }, bookDto);
        }



        [HttpPut("books/{id}")]

        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBook updateBook)
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            _mapper.Map(updateBook, book);
            var updatedBook = await _bookRepository.Update(book);
            var bookDto = _mapper.Map<GetBookDto>(updatedBook);
            return Ok(bookDto);
        }



        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _bookRepository.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            var deletedBook = await _bookRepository.Delete(id);
            var bookDto = _mapper.Map<GetBookDto>(deletedBook);
            return Ok(bookDto);
        }
    }

}
